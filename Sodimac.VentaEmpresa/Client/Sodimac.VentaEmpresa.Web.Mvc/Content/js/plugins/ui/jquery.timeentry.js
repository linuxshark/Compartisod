/* http://keith-wood.name/timeEntry.html
   Time entry for jQuery v1.4.9.
   Written by Keith Wood (kbwood{at}iinet.com.au) June 2007.
   Dual licensed under the GPL (http://dev.jquery.com/browser/trunk/jquery/GPL-LICENSE.txt) and 
   MIT (http://dev.jquery.com/browser/trunk/jquery/MIT-LICENSE.txt) licenses. 
   Please attribute the author if you use it. */
(function($){function TimeEntry(){this._disabledInputs=[];this.regional=[];this.regional['']={show24Hours:false,separator:':',ampmPrefix:'',ampmNames:['AM','PM'],spinnerTexts:['Now','Previous field','Next field','Increment','Decrement']};this._defaults={appendText:'',showSeconds:false,timeSteps:[1,1,1],initialField:0,useMouseWheel:true,defaultTime:null,minTime:null,maxTime:null,spinnerImage:'spinnerDefault.png',spinnerSize:[20,20,8],spinnerBigImage:'',spinnerBigSize:[40,40,16],spinnerIncDecOnly:false,spinnerRepeat:[500,250],beforeShow:null,beforeSetTime:null};$.extend(this._defaults,this.regional[''])}var m='timeEntry';$.extend(TimeEntry.prototype,{markerClassName:'hasTimeEntry',setDefaults:function(a){extendRemove(this._defaults,a||{});return this},_connectTimeEntry:function(b,c){var d=$(b);if(d.hasClass(this.markerClassName)){return}var e={};e.options=$.extend({},c);e._selectedHour=0;e._selectedMinute=0;e._selectedSecond=0;e._field=0;e.input=$(b);$.data(b,m,e);var f=this._get(e,'spinnerImage');var g=this._get(e,'spinnerText');var h=this._get(e,'spinnerSize');var i=this._get(e,'appendText');var j=(!f?null:$('<span class="timeEntry_control" style="display: inline-block; '+'background: url(\''+f+'\') 0 0 no-repeat; '+'width: '+h[0]+'px; height: '+h[1]+'px;'+($.browser.mozilla&&$.browser.version<'1.9'?' padding-left: '+h[0]+'px; padding-bottom: '+(h[1]-18)+'px;':'')+'"></span>'));d.wrap('<span class="timeEntry_wrap"></span>').after(i?'<span class="timeEntry_append">'+i+'</span>':'').after(j||'');d.addClass(this.markerClassName).bind('focus.timeEntry',this._doFocus).bind('blur.timeEntry',this._doBlur).bind('click.timeEntry',this._doClick).bind('keydown.timeEntry',this._doKeyDown).bind('keypress.timeEntry',this._doKeyPress);if($.browser.mozilla){d.bind('input.timeEntry',function(a){$.timeEntry._parseTime(e)})}if($.browser.msie){d.bind('paste.timeEntry',function(a){setTimeout(function(){$.timeEntry._parseTime(e)},1)})}if(this._get(e,'useMouseWheel')&&$.fn.mousewheel){d.mousewheel(this._doMouseWheel)}if(j){j.mousedown(this._handleSpinner).mouseup(this._endSpinner).mouseover(this._expandSpinner).mouseout(this._endSpinner).mousemove(this._describeSpinner)}},_enableTimeEntry:function(a){this._enableDisable(a,false)},_disableTimeEntry:function(a){this._enableDisable(a,true)},_enableDisable:function(b,c){var d=$.data(b,m);if(!d){return}b.disabled=c;if(b.nextSibling&&b.nextSibling.nodeName.toLowerCase()=='span'){$.timeEntry._changeSpinner(d,b.nextSibling,(c?5:-1))}$.timeEntry._disabledInputs=$.map($.timeEntry._disabledInputs,function(a){return(a==b?null:a)});if(c){$.timeEntry._disabledInputs.push(b)}},_isDisabledTimeEntry:function(a){return $.inArray(a,this._disabledInputs)>-1},_changeTimeEntry:function(a,b,c){var d=$.data(a,m);if(d){if(typeof b=='string'){var e=b;b={};b[e]=c}var f=this._extractTime(d);extendRemove(d.options,b||{});if(f){this._setTime(d,new Date(0,0,0,f[0],f[1],f[2]))}}$.data(a,m,d)},_destroyTimeEntry:function(b){$input=$(b);if(!$input.hasClass(this.markerClassName)){return}$input.removeClass(this.markerClassName).unbind('.timeEntry');if($.fn.mousewheel){$input.unmousewheel()}this._disabledInputs=$.map(this._disabledInputs,function(a){return(a==b?null:a)});$input.parent().replaceWith($input);$.removeData(b,m)},_setTimeTimeEntry:function(a,b){var c=$.data(a,m);if(c){if(b===null||b===''){c.input.val('')}else{this._setTime(c,b?(typeof b=='object'?new Date(b.getTime()):b):null)}}},_getTimeTimeEntry:function(a){var b=$.data(a,m);var c=(b?this._extractTime(b):null);return(!c?null:new Date(0,0,0,c[0],c[1],c[2]))},_getOffsetTimeEntry:function(a){var b=$.data(a,m);var c=(b?this._extractTime(b):null);return(!c?0:(c[0]*3600+c[1]*60+c[2])*1000)},_doFocus:function(a){var b=(a.nodeName&&a.nodeName.toLowerCase()=='input'?a:this);if($.timeEntry._lastInput==b||$.timeEntry._isDisabledTimeEntry(b)){$.timeEntry._focussed=false;return}var c=$.data(b,m);$.timeEntry._focussed=true;$.timeEntry._lastInput=b;$.timeEntry._blurredInput=null;var d=$.timeEntry._get(c,'beforeShow');extendRemove(c.options,(d?d.apply(b,[b]):{}));$.data(b,m,c);$.timeEntry._parseTime(c);setTimeout(function(){$.timeEntry._showField(c)},10)},_doBlur:function(a){$.timeEntry._blurredInput=$.timeEntry._lastInput;$.timeEntry._lastInput=null},_doClick:function(b){var c=b.target;var d=$.data(c,m);if(!$.timeEntry._focussed){var e=$.timeEntry._get(d,'separator').length+2;d._field=0;if(c.selectionStart!=null){for(var f=0;f<=Math.max(1,d._secondField,d._ampmField);f++){var g=(f!=d._ampmField?(f*e)+2:(d._ampmField*e)+$.timeEntry._get(d,'ampmPrefix').length+$.timeEntry._get(d,'ampmNames')[0].length);d._field=f;if(c.selectionStart<g){break}}}else if(c.createTextRange){var h=$(b.srcElement);var i=c.createTextRange();var j=function(a){return{thin:2,medium:4,thick:6}[a]||a};var k=b.clientX+document.documentElement.scrollLeft-(h.offset().left+parseInt(j(h.css('border-left-width')),10))-i.offsetLeft;for(var f=0;f<=Math.max(1,d._secondField,d._ampmField);f++){var g=(f!=d._ampmField?(f*e)+2:(d._ampmField*e)+$.timeEntry._get(d,'ampmPrefix').length+$.timeEntry._get(d,'ampmNames')[0].length);i.collapse();i.moveEnd('character',g);d._field=f;if(k<i.boundingWidth){break}}}}$.data(c,m,d);$.timeEntry._showField(d);$.timeEntry._focussed=false},_doKeyDown:function(a){if(a.keyCode>=48){return true}var b=$.data(a.target,m);switch(a.keyCode){case 9:return(a.shiftKey?$.timeEntry._changeField(b,-1,true):$.timeEntry._changeField(b,+1,true));case 35:if(a.ctrlKey){$.timeEntry._setValue(b,'')}else{b._field=Math.max(1,b._secondField,b._ampmField);$.timeEntry._adjustField(b,0)}break;case 36:if(a.ctrlKey){$.timeEntry._setTime(b)}else{b._field=0;$.timeEntry._adjustField(b,0)}break;case 37:$.timeEntry._changeField(b,-1,false);break;case 38:$.timeEntry._adjustField(b,+1);break;case 39:$.timeEntry._changeField(b,+1,false);break;case 40:$.timeEntry._adjustField(b,-1);break;case 46:$.timeEntry._setValue(b,'');break}return false},_doKeyPress:function(a){var b=String.fromCharCode(a.charCode==undefined?a.keyCode:a.charCode);if(b<' '){return true}var c=$.data(a.target,m);$.timeEntry._handleKeyPress(c,b);return false},_doMouseWheel:function(a,b){if($.timeEntry._isDisabledTimeEntry(a.target)){return}b=($.browser.opera?-b/Math.abs(b):($.browser.safari?b/Math.abs(b):b));var c=$.data(a.target,m);c.input.focus();if(!c.input.val()){$.timeEntry._parseTime(c)}$.timeEntry._adjustField(c,b);a.preventDefault()},_expandSpinner:function(b){var c=$.timeEntry._getSpinnerTarget(b);var d=$.data($.timeEntry._getInput(c),m);if($.timeEntry._isDisabledTimeEntry(d.input[0])){return}var e=$.timeEntry._get(d,'spinnerBigImage');if(e){d._expanded=true;var f=$(c).offset();var g=null;$(c).parents().each(function(){var a=$(this);if(a.css('position')=='relative'||a.css('position')=='absolute'){g=a.offset()}return!g});var h=$.timeEntry._get(d,'spinnerSize');var i=$.timeEntry._get(d,'spinnerBigSize');$('<div class="timeEntry_expand" style="position: absolute; left: '+(f.left-(i[0]-h[0])/2-(g?g.left:0))+'px; top: '+(f.top-(i[1]-h[1])/2-(g?g.top:0))+'px; width: '+i[0]+'px; height: '+i[1]+'px; background: transparent url('+e+') no-repeat 0px 0px; z-index: 10;"></div>').mousedown($.timeEntry._handleSpinner).mouseup($.timeEntry._endSpinner).mouseout($.timeEntry._endExpand).mousemove($.timeEntry._describeSpinner).insertAfter(c)}},_getInput:function(a){return $(a).siblings('.'+$.timeEntry.markerClassName)[0]},_describeSpinner:function(a){var b=$.timeEntry._getSpinnerTarget(a);var c=$.data($.timeEntry._getInput(b),m);b.title=$.timeEntry._get(c,'spinnerTexts')[$.timeEntry._getSpinnerRegion(c,a)]},_handleSpinner:function(a){var b=$.timeEntry._getSpinnerTarget(a);var c=$.timeEntry._getInput(b);if($.timeEntry._isDisabledTimeEntry(c)){return}if(c==$.timeEntry._blurredInput){$.timeEntry._lastInput=c;$.timeEntry._blurredInput=null}var d=$.data(c,m);$.timeEntry._doFocus(c);var e=$.timeEntry._getSpinnerRegion(d,a);$.timeEntry._changeSpinner(d,b,e);$.timeEntry._actionSpinner(d,e);$.timeEntry._timer=null;$.timeEntry._handlingSpinner=true;var f=$.timeEntry._get(d,'spinnerRepeat');if(e>=3&&f[0]){$.timeEntry._timer=setTimeout(function(){$.timeEntry._repeatSpinner(d,e)},f[0]);$(b).one('mouseout',$.timeEntry._releaseSpinner).one('mouseup',$.timeEntry._releaseSpinner)}},_actionSpinner:function(a,b){if(!a.input.val()){$.timeEntry._parseTime(a)}switch(b){case 0:this._setTime(a);break;case 1:this._changeField(a,-1,false);break;case 2:this._changeField(a,+1,false);break;case 3:this._adjustField(a,+1);break;case 4:this._adjustField(a,-1);break}},_repeatSpinner:function(a,b){if(!$.timeEntry._timer){return}$.timeEntry._lastInput=$.timeEntry._blurredInput;this._actionSpinner(a,b);this._timer=setTimeout(function(){$.timeEntry._repeatSpinner(a,b)},this._get(a,'spinnerRepeat')[1])},_releaseSpinner:function(a){clearTimeout($.timeEntry._timer);$.timeEntry._timer=null},_endExpand:function(a){$.timeEntry._timer=null;var b=$.timeEntry._getSpinnerTarget(a);var c=$.timeEntry._getInput(b);var d=$.data(c,m);$(b).remove();d._expanded=false},_endSpinner:function(a){$.timeEntry._timer=null;var b=$.timeEntry._getSpinnerTarget(a);var c=$.timeEntry._getInput(b);var d=$.data(c,m);if(!$.timeEntry._isDisabledTimeEntry(c)){$.timeEntry._changeSpinner(d,b,-1)}if($.timeEntry._handlingSpinner){$.timeEntry._lastInput=$.timeEntry._blurredInput}if($.timeEntry._lastInput&&$.timeEntry._handlingSpinner){$.timeEntry._showField(d)}$.timeEntry._handlingSpinner=false},_getSpinnerTarget:function(a){return a.target||a.srcElement},_getSpinnerRegion:function(a,b){var c=this._getSpinnerTarget(b);var d=($.browser.opera||$.browser.safari?$.timeEntry._findPos(c):$(c).offset());var e=($.browser.safari?$.timeEntry._findScroll(c):[document.documentElement.scrollLeft||document.body.scrollLeft,document.documentElement.scrollTop||document.body.scrollTop]);var f=this._get(a,'spinnerIncDecOnly');var g=(f?99:b.clientX+e[0]-d.left-($.browser.msie?2:0));var h=b.clientY+e[1]-d.top-($.browser.msie?2:0);var i=this._get(a,(a._expanded?'spinnerBigSize':'spinnerSize'));var j=(f?99:i[0]-1-g);var k=i[1]-1-h;if(i[2]>0&&Math.abs(g-j)<=i[2]&&Math.abs(h-k)<=i[2]){return 0}var l=Math.min(g,h,j,k);return(l==g?1:(l==j?2:(l==h?3:4)))},_changeSpinner:function(a,b,c){$(b).css('','-'+((c+1)*this._get(a,(a._expanded?'spinnerBigSize':'spinnerSize'))[0])+'px 0px')},_findPos:function(a){var b=curTop=0;if(a.offsetParent){b=a.offsetLeft;curTop=a.offsetTop;while(a=a.offsetParent){var c=b;b+=a.offsetLeft;if(b<0){b=c}curTop+=a.offsetTop}}return{left:b,top:curTop}},_findScroll:function(a){var b=false;$(a).parents().each(function(){b|=$(this).css('position')=='fixed'});if(b){return[0,0]}var c=a.scrollLeft;var d=a.scrollTop;while(a=a.parentNode){c+=a.scrollLeft||0;d+=a.scrollTop||0}return[c,d]},_get:function(a,b){return(a.options[b]!=null?a.options[b]:$.timeEntry._defaults[b])},_parseTime:function(a){var b=this._extractTime(a);var c=this._get(a,'showSeconds');if(b){a._selectedHour=b[0];a._selectedMinute=b[1];a._selectedSecond=b[2]}else{var d=this._constrainTime(a);a._selectedHour=d[0];a._selectedMinute=d[1];a._selectedSecond=(c?d[2]:0)}a._secondField=(c?2:-1);a._ampmField=(this._get(a,'show24Hours')?-1:(c?3:2));a._lastChr='';a._field=Math.max(0,Math.min(Math.max(1,a._secondField,a._ampmField),this._get(a,'initialField')));if(a.input.val()!=''){this._showTime(a)}},_extractTime:function(a,b){b=b||a.input.val();var c=this._get(a,'separator');var d=b.split(c);if(c==''&&b!=''){d[0]=b.substring(0,2);d[1]=b.substring(2,4);d[2]=b.substring(4,6)}var e=this._get(a,'ampmNames');var f=this._get(a,'show24Hours');if(d.length>=2){var g=!f&&(b.indexOf(e[0])>-1);var h=!f&&(b.indexOf(e[1])>-1);var i=parseInt(d[0],10);i=(isNaN(i)?0:i);i=((g||h)&&i==12?0:i)+(h?12:0);var j=parseInt(d[1],10);j=(isNaN(j)?0:j);var k=(d.length>=3?parseInt(d[2],10):0);k=(isNaN(k)||!this._get(a,'showSeconds')?0:k);return this._constrainTime(a,[i,j,k])}return null},_constrainTime:function(a,b){var c=(b!=null);if(!c){var d=this._determineTime(a,this._get(a,'defaultTime'))||new Date();b=[d.getHours(),d.getMinutes(),d.getSeconds()]}var e=false;var f=this._get(a,'timeSteps');for(var i=0;i<f.length;i++){if(e){b[i]=0}else if(f[i]>1){b[i]=Math.round(b[i]/f[i])*f[i];e=true}}return b},_showTime:function(a){var b=this._get(a,'show24Hours');var c=this._get(a,'separator');var d=(this._formatNumber(b?a._selectedHour:((a._selectedHour+11)%12)+1)+c+this._formatNumber(a._selectedMinute)+(this._get(a,'showSeconds')?c+this._formatNumber(a._selectedSecond):'')+(b?'':this._get(a,'ampmPrefix')+this._get(a,'ampmNames')[(a._selectedHour<12?0:1)]));this._setValue(a,d);this._showField(a)},_showField:function(a){var b=a.input[0];if(a.input.is(':hidden')||$.timeEntry._lastInput!=b){return}var c=this._get(a,'separator');var d=c.length+2;var e=(a._field!=a._ampmField?(a._field*d):(a._ampmField*d)-c.length+this._get(a,'ampmPrefix').length);var f=e+(a._field!=a._ampmField?2:this._get(a,'ampmNames')[0].length);if(b.setSelectionRange){b.setSelectionRange(e,f)}else if(b.createTextRange){var g=b.createTextRange();g.moveStart('character',e);g.moveEnd('character',f-a.input.val().length);g.select()}if(!b.disabled){b.focus()}},_formatNumber:function(a){return(a<10?'0':'')+a},_setValue:function(a,b){if(b!=a.input.val()){a.input.val(b).trigger('change')}},_changeField:function(a,b,c){var d=(a.input.val()==''||a._field==(b==-1?0:Math.max(1,a._secondField,a._ampmField)));if(!d){a._field+=b}this._showField(a);a._lastChr='';$.data(a.input[0],m,a);return(d&&c)},_adjustField:function(a,b){if(a.input.val()==''){b=0}var c=this._get(a,'timeSteps');this._setTime(a,new Date(0,0,0,a._selectedHour+(a._field==0?b*c[0]:0)+(a._field==a._ampmField?b*12:0),a._selectedMinute+(a._field==1?b*c[1]:0),a._selectedSecond+(a._field==a._secondField?b*c[2]:0)))},_setTime:function(a,b){b=this._determineTime(a,b);var c=this._constrainTime(a,b?[b.getHours(),b.getMinutes(),b.getSeconds()]:null);b=new Date(0,0,0,c[0],c[1],c[2]);var b=this._normaliseTime(b);var d=this._normaliseTime(this._determineTime(a,this._get(a,'minTime')));var e=this._normaliseTime(this._determineTime(a,this._get(a,'maxTime')));b=(d&&b<d?d:(e&&b>e?e:b));var f=this._get(a,'beforeSetTime');if(f){b=f.apply(a.input[0],[this._getTimeTimeEntry(a.input[0]),b,d,e])}a._selectedHour=b.getHours();a._selectedMinute=b.getMinutes();a._selectedSecond=b.getSeconds();this._showTime(a);$.data(a.input[0],m,a)},_normaliseTime:function(a){if(!a){return null}a.setFullYear(1900);a.setMonth(0);a.setDate(0);return a},_determineTime:function(i,j){var k=function(a){var b=new Date();b.setTime(b.getTime()+a*1000);return b};var l=function(a){var b=$.timeEntry._extractTime(i,a);var c=new Date();var d=(b?b[0]:c.getHours());var e=(b?b[1]:c.getMinutes());var f=(b?b[2]:c.getSeconds());if(!b){var g=/([+-]?[0-9]+)\s*(s|S|m|M|h|H)?/g;var h=g.exec(a);while(h){switch(h[2]||'s'){case's':case'S':f+=parseInt(h[1],10);break;case'm':case'M':e+=parseInt(h[1],10);break;case'h':case'H':d+=parseInt(h[1],10);break}h=g.exec(a)}}c=new Date(0,0,10,d,e,f,0);if(/^!/.test(a)){if(c.getDate()>10){c=new Date(0,0,10,23,59,59)}else if(c.getDate()<10){c=new Date(0,0,10,0,0,0)}}return c};return(j?(typeof j=='string'?l(j):(typeof j=='number'?k(j):j)):null)},_handleKeyPress:function(a,b){if(b==this._get(a,'separator')){this._changeField(a,+1,false)}else if(b>='0'&&b<='9'){var c=parseInt(b,10);var d=parseInt(a._lastChr+b,10);var e=this._get(a,'show24Hours');var f=(a._field!=0?a._selectedHour:(e?(d<24?d:c):(d>=1&&d<=12?d:(c>0?c:a._selectedHour))%12+(a._selectedHour>=12?12:0)));var g=(a._field!=1?a._selectedMinute:(d<60?d:c));var h=(a._field!=a._secondField?a._selectedSecond:(d<60?d:c));var i=this._constrainTime(a,[f,g,h]);this._setTime(a,new Date(0,0,0,i[0],i[1],i[2]));a._lastChr=b}else if(!this._get(a,'show24Hours')){b=b.toLowerCase();var j=this._get(a,'ampmNames');if((b==j[0].substring(0,1).toLowerCase()&&a._selectedHour>=12)||(b==j[1].substring(0,1).toLowerCase()&&a._selectedHour<12)){var k=a._field;a._field=a._ampmField;this._adjustField(a,+1);a._field=k;this._showField(a)}}}});function extendRemove(a,b){$.extend(a,b);for(var c in b){if(b[c]==null){a[c]=null}}return a}var n=['getOffset','getTime','isDisabled'];$.fn.timeEntry=function(c){var d=Array.prototype.slice.call(arguments,1);if(typeof c=='string'&&$.inArray(c,n)>-1){return $.timeEntry['_'+c+'TimeEntry'].apply($.timeEntry,[this[0]].concat(d))}return this.each(function(){var a=this.nodeName.toLowerCase();if(a=='input'){if(typeof c=='string'){$.timeEntry['_'+c+'TimeEntry'].apply($.timeEntry,[this].concat(d))}else{var b=($.fn.metadata?$(this).metadata():{});$.timeEntry._connectTimeEntry(this,$.extend(b,c))}}})};$.timeEntry=new TimeEntry()})(jQuery);