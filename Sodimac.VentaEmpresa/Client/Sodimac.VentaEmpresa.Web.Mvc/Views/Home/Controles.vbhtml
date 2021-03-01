﻿@Code
    ViewData("Title") = "Controles"
End Code
    <div class="contentTop">
        <span class="pageTitle"><span class="icon-screen"></span></span>
        <div class="clear"></div>
    </div>
    
    <!-- Breadcrumbs line -->
    <div class="breadLine">
        <div class="bc">
            <ul id="breadcrumbs" class="breadcrumbs">
                <li><a href="#">Inicio</a></li>
                <li><a href="#">Controles</a>
                    <ul>
                        <li><a href="#" title="">Formularios</a></li>
                        <li><a href="#" title="">Editor WYSIWYG</a></li>
                        <li><a href="#" title="">Calendario wizards</a></li>
                        <li><a href="#" title="">UI Elementos</a></li>
                        <li><a href="#" title="">Charts</a></li>
                    </ul>
                </li>
                <li class="current"><a href="#" title="">Demo UI Komatsu</a></li>
            </ul>
        </div>
        
        <div class="breadLinks">
            <ul>
                <li><a href="#demo_form" title=""><i class="icos-list"></i><span>Form</span></a></li>
                <li><a href="#demo_calendar" title=""><i class="icos-check"></i><span>Calendar</span></a></li>
                <li class="has">
                    <a title="">
                        <i class="icos-money3"></i>
                        <span>Items</span>
                        <span><img src='@Url.Content("~/Content/images/elements/control/hasddArrow.png")' alt="" /></span>
                    </a>
                    <ul>
                        <li><a href="#" title=""><span class="icos-add"></span>A Form</a></li>
                        <li><a href="#" title=""><span class="icos-archive"></span>B Calendar</a></li>
                        <li><a href="#" title=""><span class="icos-printer"></span>C Validation</a></li>
                    </ul>
                </li>
            </ul>
             <div class="clear"></div>
        </div>
    </div>

    <!-- Main content -->
    <div class="wrapper">

        <div id="demo_form" class="main">
            <fieldset>
                <div class="widget fluid">
                    <div class="whead"><h6>Input fields</h6><div class="clear"></div></div>
                    <div class="formRow">
                        <div class="grid3"><label>Usual input field:</label></div>
                        <div class="grid9"><input type="text" name="regular" /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Password field:</label></div>
                        <div class="grid9"><input type="password" name="pass" /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>With placeholder:</label></div>
                        <div class="grid9"><input type="text" name="placeholder" placeholder="Bazinga" /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Read only field:</label></div>
                        <div class="grid9"><input type="text" name="readonly" readonly="readonly" value="read only" /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Disabled field:</label></div>
                        <div class="grid9"><input type="text" name="disabled" disabled="disabled" value="disabled" /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Field with notice:</label></div>
                        <div class="grid9"><input type="text" name="regular" /><span class="note">Some nice stuff goes here</span></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Label with notice:<span class="note">The same stuff here</span></label></div>
                        <div class="grid9"><input type="text" name="regular" /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Predefined value:</label></div>
                        <div class="grid9"><input type="text" name="regular" value="http://" /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Field with tooltip:</label></div>
                        <div class="grid9"><input type="text" name="regular" title="Tooltip in different directions" class="tipS" /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Max 10 characters:</label></div>
                        <div class="grid9"><input type="text" name="regular" maxlength="10" placeholder="Max 10 characters" /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label><span class="icos-user"></span>With icons:</label></div>
                        <div class="grid9">
                            <input type="text" name="regular" />
                            <img src="~/Content/images/icons/usual/icon-download.png" alt="" class="fieldIcon" />
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label for="labelfor">Clickable label:</label></div>
                        <div class="grid9"><input type="text" name="labelfor" id="labelfor" /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Textarea:</label></div>
                        <div class="grid9"><textarea rows="8" cols="" name="textarea"></textarea> </div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Elastic textarea:</label></div>
                        <div class="grid9"><textarea rows="8" cols="" name="textarea" class="auto"></textarea></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>With character counter:</label></div>
                        <div class="grid9">
                            <textarea rows="8" cols="" name="textarea" class="auto lim"></textarea>
                            <span class="note" id="limitingtext">Field limited to 100 characters.</span>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Tags:</label></div>
                        <div class="grid9"><input type="text" id="tags" name="tags" class="tags" value="these,are,sample,tags" /></div>
                        <div class="clear"></div>
                    </div>
                </div>
            </fieldset>
    
            <fieldset>
                <div class="widget fluid">
                    <div class="whead"><h6>Fields with masked values</h6><div class="clear"></div></div>
                    <div class="formRow">
                        <div class="grid3"><label>Date:</label></div>
                        <div class="grid9"><input type="text" class="maskDate" id="maskDate" value="value" /><span class="note">99/99/9999</span></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Phone:</label></div>
                        <div class="grid9"><input type="text" class="maskPhone" value="" /><span class="note">(999) 999-9999</span></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Phone + Ext:</label></div>
                        <div class="grid9"><input type="text" class="maskPhoneExt" value="" /><span class="note">(999) 999-9999? x99999</span></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Int'l Phone:</label></div>
                        <div class="grid9"><input type="text" class="maskIntPhone" value="" /><span class="note">+33 999 999 999</span></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Tax ID:</label></div>
                        <div class="grid9"><input type="text" class="maskTin" value="" /><span class="note">99-9999999</span></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>SSN:</label></div>
                        <div class="grid9"><input type="text" class="maskSsn" /><span class="note">999-99-9999</span></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Product Key:</label></div>
                        <div class="grid9"><input type="text" class="maskProd" /><span class="note">a*-999-a999</span></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Eye Script:</label></div>
                        <div class="grid9"><input type="text" class="maskEye" /><span class="note">~9.99 ~9.99 999</span></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Purchase Order:</label></div>
                        <div class="grid9"><input type="text" class="maskPo" value="" /><span class="note">aaa-999-***</span></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Percent:</label></div>
                        <div class="grid9"><input type="text" class="maskPct" value="" /><span class="note">99%</span></div>
                        <div class="clear"></div>
                    </div>
                </div>
                <div id="unmask"></div>
            </fieldset>
        
            <fieldset>
                <div class="widget fluid">
                    <div class="whead"><h6>Autotabs</h6><div class="clear"></div></div>
                    <div class="formRow">
                        <div class="grid3"><label>Simple data row</label> </div>
                        <div class="grid9 moreFields">
                            <ul class="rowData">
                                <li><input type="text" name="test" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="test" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="test" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="test" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="test" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="test" maxlength="6" /></li>
                            </ul> 
                            <div class="clear"></div>  
                        </div> 
                        <div class="clear"></div> 
                    </div>
                    
                    <div class="formRow">
                        <div class="grid3"><label>Numbers only</label> </div>
                        <div class="grid9 moreFields onlyNums">
                            <ul>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                            </ul>  
                            <div class="clear"></div> 
                        </div> 
                        <div class="clear"></div> 
                    </div>
    
                    <div class="formRow">
                        <div class="grid3"><label>Letters only</label> </div>
                        <div class="grid9 moreFields onlyText">
                            <ul>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                            </ul>  
                            <div class="clear"></div> 
                        </div> 
                        <div class="clear"></div> 
                    </div>
                    
                    <div class="formRow">
                        <div class="grid3"><label>Alpha only</label></div>
                        <div class="grid9 moreFields onlyAlpha">
                            <ul>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                            </ul>  
                            <div class="clear"></div> 
                        </div> 
                        <div class="clear"></div> 
                    </div>
    
                    <div class="formRow">
                        <div class="grid3"><label>Regular expressions</label> </div>
                        <div class="grid9 moreFields onlyRegex">
                            <ul>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="question" maxlength="6" /></li>
                            </ul>  
                            <div class="clear"></div> 
                        </div> 
                        <div class="clear"></div> 
                    </div>
                    
                    <div class="formRow">
                        <div class="grid3"><label>Uppercase converting</label> </div>
                        <div class="grid9 moreFields allUpper">
                            <ul>
                                <li><input type="text" name="up1" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="up2" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="up3" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="up4" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="up5" maxlength="6" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" name="up6" maxlength="6" /></li>
                            </ul>  
                            <div class="clear"></div> 
                        </div> 
                        <div class="clear"></div>
                    </div>
                </div>   
            </fieldset>
        
            <fieldset>
                <div class="fluid">
                    <div class="widget grid6">
                        <div class="whead"><h6>Dropdowns and selects</h6><div class="clear"></div></div>
                        <div class="formRow">
                            <div class="grid3"><label>Select with scrolling :</label></div>
                            <div class="grid9">
                            <select name="select2" >
                                <option value="opt1">Usual select box</option>
                                <option value="opt2">Option 2</option>
                                <option value="opt3">Option 3</option>
                                <option value="opt4">Option 4</option>
                                <option value="opt5">Option 5</option>
                                <option value="opt6">Option 6</option>
                                <option value="opt7">Option 7</option>
                                <option value="opt8">Option 8</option>
                            </select>
                            </div>
                            <div class="clear"></div>
                        </div>
                    
                        <div class="formRow">
                            <div class="grid3"><label>Styled dropdown :</label></div>
                            <div class="grid9 noSearch">
                            <select name="select2" class="select">
                                <option value="opt1">Usual select box with dropdown styling</option>
                                <option value="opt2">Option 2</option>
                                <option value="opt3">Option 3</option>
                                <option value="opt4">Option 4</option>
                                <option value="opt5">Option 5</option>
                                <option value="opt6">Option 6</option>
                                <option value="opt7">Option 7</option>
                                <option value="opt8">Option 8</option>
                            </select>
                            </div>
                            <div class="clear"></div>
                        </div>
                    
@*                        <div class="formRow">
                            <div class="grid3"><label>Select with search:</label></div>
                            <div class="grid9 searchDrop">
                                <select data-placeholder="Choose a Country..." class="select" style="width:350px;" tabindex="2">
                                    <option value=""></option> 
                                    <option value="Cambodia">Cambodia</option> 
                                    <option value="Cameroon">Cameroon</option> 
                                    <option value="Canada">Canada</option> 
                                    <option value="Cape Verde">Cape Verde</option> 
                                    <option value="Cayman Islands">Cayman Islands</option> 
                                    <option value="Central African Republic">Central African Republic</option> 
                                    <option value="Chad">Chad</option> 
                                    <option value="Chile">Chile</option> 
                                    <option value="China">China</option> 
                                    <option value="Christmas Island">Christmas Island</option> 
                                    <option value="Cocos (Keeling) Islands">Cocos (Keeling) Islands</option> 
                                    <option value="Colombia">Colombia</option> 
                                    <option value="Comoros">Comoros</option> 
                                    <option value="Congo">Congo</option> 
                                    <option value="Congo, The Democratic Republic of The">Congo, The Democratic Republic of The</option> 
                                    <option value="Cook Islands">Cook Islands</option> 
                                    <option value="Costa Rica">Costa Rica</option> 
                                    <option value="Cote D'ivoire">Cote D'ivoire</option> 
                                    <option value="Croatia">Croatia</option> 
                                    <option value="Cuba">Cuba</option> 
                                    <option value="Cyprus">Cyprus</option> 
                                    <option value="Czech Republic">Czech Republic</option> 
                                    <option value="Denmark">Denmark</option> 
                                    <option value="Djibouti">Djibouti</option> 
                                    <option value="Dominica">Dominica</option> 
                                    <option value="Dominican Republic">Dominican Republic</option> 
                                    <option value="Ecuador">Ecuador</option> 
                                    <option value="Egypt">Egypt</option> 
                                    <option value="El Salvador">El Salvador</option> 
                                    <option value="Equatorial Guinea">Equatorial Guinea</option> 
                                    <option value="Eritrea">Eritrea</option> 
                                    <option value="Estonia">Estonia</option> 
                                    <option value="Ethiopia">Ethiopia</option> 
                                    <option value="Falkland Islands (Malvinas)">Falkland Islands (Malvinas)</option> 
                                    <option value="Faroe Islands">Faroe Islands</option> 
                                    <option value="Fiji">Fiji</option> 
                                    <option value="Finland">Finland</option> 
                                    <option value="France">France</option> 
                                    <option value="French Guiana">French Guiana</option> 
                                    <option value="French Polynesia">French Polynesia</option> 
                                    <option value="French Southern Territories">French Southern Territories</option> 
                                    <option value="Gabon">Gabon</option> 
                                    <option value="Gambia">Gambia</option> 
                                    <option value="Georgia">Georgia</option> 
                                    <option value="Germany">Germany</option> 
                                    <option value="Ghana">Ghana</option> 
                                    <option value="Gibraltar">Gibraltar</option> 
                                    <option value="Greece">Greece</option> 
                                </select>
                            </div>             
                            <div class="clear"></div>
                        </div>*@
                    
                        <div class="formRow">
                            <div class="grid3"><label>Bootstrap dropdowns:</label></div>
                            <div class="grid9">
                                <ul class="navi nav-pills">
                                  <li class="active"><a href="#">Regular link</a></li>
                                  <li>|</li>
                                  <li class="active"><a href="#">Regular link</a></li>
                                  <li>|</li>
                                  <li class="dropdown" id="menu1">
                                    <a class="dropdown-toggle" data-toggle="dropdown" href="#menu1">
                                      Dropdown
                                      <b class="caret"></b>
                                    </a>
                                    <ul class="dropdown-menu">
                                    <li><a href="#"><span class="icos-add"></span>Add</a></li>
                                    <li><a href="#"><span class="icos-trash"></span>Remove</a></li>
                                    <li><a href="#" class=""><span class="icos-pencil"></span>Edit</a></li>
                                    <li><a href="#" class=""><span class="icos-heart"></span>Do whatever you like</a></li>
                                    </ul>
                                  </li>
                                </ul>                        
                            </div>
                            <div class="clear"></div>
                        </div>
                    
                        <div class="formRow">
                            <div class="grid3"><label>Multiple with search:</label></div>
                            <div class="grid9">
                                <select data-placeholder="Your Favorite Football Team" class="fullwidth select" multiple="multiple" tabindex="6">
                                    <option value=""></option>
                                    <optgroup label="NFC EAST">
                                        <option>Dallas Cowboys</option>
                                        <option selected="selected">New York Giants</option>
                                        <option>Philadelphia Eagles</option>
                                        <option>Washington Redskins</option>
                                    </optgroup>
                                    <optgroup label="NFC NORTH">
                                        <option selected="selected">Chicago Bears</option>
                                        <option>Detroit Lions</option>
                                        <option>Green Bay Packers</option>
                                        <option>Minnesota Vikings</option>
                                    </optgroup>
                                    <optgroup label="NFC SOUTH">
                                        <option selected="selected">Atlanta Falcons</option>
                                        <option>Carolina Panthers</option>
                                        <option>New Orleans Saints</option>
                                        <option>Tampa Bay Buccaneers</option>
                                    </optgroup>
                                    <optgroup label="NFC WEST">
                                        <option>Arizona Cardinals</option>
                                        <option>St. Louis Rams</option>
                                        <option>San Francisco 49ers</option>
                                        <option>Seattle Seahawks</option>
                                    </optgroup>
                                    <optgroup label="AFC EAST">
                                        <option>Buffalo Bills</option>
                                        <option>Miami Dolphins</option>
                                        <option>New England Patriots</option>
                                        <option>New York Jets</option>
                                    </optgroup>
                                    <optgroup label="AFC NORTH">
                                        <option>Baltimore Ravens</option>
                                        <option>Cincinnati Bengals</option>
                                        <option>Cleveland Browns</option>
                                        <option>Pittsburgh Steelers</option>
                                    </optgroup>
                                    <optgroup label="AFC SOUTH">
                                        <option>Houston Texans</option>
                                        <option>Indianapolis Colts</option>
                                        <option>Jacksonville Jaguars</option>
                                        <option>Tennessee Titans</option>
                                    </optgroup>
                                    <optgroup label="AFC WEST">
                                        <option>Denver Broncos</option>
                                        <option>Kansas City Chiefs</option>
                                        <option>Oakland Raiders</option>
                                        <option>San Diego Chargers</option>
                                    </optgroup>
                                </select>  
                            </div>             
                            <div class="clear"></div>
                        </div>
                    
                        <div class="formRow">
                            <div class="grid3"><label>Multiple selects :</label></div>
                            <div class="grid9">
                                <select multiple="multiple" class="multiple" title="Click to Select a City">
                                <option selected="selected">Amsterdam</option>      
                                <option selected="selected">Atlanta</option>
                                <option>Baltimore</option>
                                <option>Boston</option>
                                <option>Buenos Aires</option>
                                <option>Calgary</option>
                                <option selected="selected">Chicago</option>
                                <option>Denver</option>
                                <option>Dubai</option>
                                <option>Frankfurt</option>
                                <option>Hong Kong</option>
                                <option>Honolulu</option>
                                <option>Houston</option>
                                <option>Kuala Lumpur</option>
                                <option>London</option>
                                <option>Los Angeles</option>
                                <option>Melbourne</option>
                                <option>Mexico City</option>
                                <option>Miami</option>
                                <option>Minneapolis</option>
                                <option>Montreal</option>
                                <option>New York City</option>
                                <option>Paris</option>
                                <option>Philadelphia</option>
                                <option>Rotterdam</option>
                                <option>San Diego</option>
                                <option>San Francisco</option>
                                <option>Sao Paulo</option>
                                <option>Seattle</option>
                                <option>Seoul</option>
                                <option>Shanghai</option>
                                <option>Singapore</option>
                                <option>Sydney</option>
                                <option>Tokyo</option>
                                <option>Toronto</option>
                                <option>Vancouver</option>
                                </select>
                            </div>
                            <div class="clear"></div>
                        </div>
                    </div>
                    
                    <div class="widget grid6">
                        <div class="whead"><h6>Checkboxes, radios and file input</h6><div class="clear"></div></div>
                        <div class="formRow">
                            <div class="grid3"><label>Checkbox: </label></div>
                            <div class="grid9 on_off">
                                <div class="floatL mr10"><input type="checkbox" id="check20" checked="checked" name="chbox" /></div>
                                <div class="floatL mr10"><input type="checkbox" id="check21" name="chbox1" /></div>
                                <div class="floatL mr10"><input type="checkbox" name="chbox1" checked="checked" disabled="disabled" /></div>
                                <div class="floatL"><input type="checkbox" name="chbox1" disabled="disabled" /></div>
                            </div>
                            <div class="clear"></div>
                        </div>
                            
                        <div class="formRow">
                            <div class="grid3"><label>Radio: </label></div>
                            <div class="grid9 on_off">
                                <div class="floatL mr10"><input type="radio" id="radio10"  name="question11" checked="checked" /></div>
                                <div class="floatL mr10"><input type="radio" id="radio11"  name="question11" /></div>
                                <div class="floatL mr10"><input type="radio" id="radio12" disabled="disabled"  name="question11" /></div>
                            </div>
                            <div class="clear"></div>
                        </div>
                            
                        <div class="formRow">
                            <div class="grid3"><label>Checkbox: </label></div>
                            <div class="grid9 yes_no">
                                <div class="floatL mr10"><input type="checkbox" id="check6" checked="checked" name="chbox" /></div>
                                <div class="floatL mr10"><input type="checkbox" id="check7" name="chbox1" /></div>
                                <div class="floatL"><input type="checkbox" name="chbox1" checked="checked" disabled="disabled" /></div>
                            </div>
                            <div class="clear"></div>
                        </div>
                            
                        <div class="formRow">
                            <div class="grid3"><label>Radio: </label></div>
                            <div class="grid9 yes_no">
                                <div class="floatL mr10"><input type="radio" id="radio13"  name="question12" checked="checked" /></div>
                                <div class="floatL mr10"><input type="radio" id="radio14"  name="question12" /></div>
                                <div class="floatL"><input type="radio" id="radio15" disabled="disabled"  name="question11" /></div>
                            </div>
                            <div class="clear"></div>
                        </div>
                            
                        <div class="formRow">
                            <div class="grid3"><label>Checkbox: </label></div>
                            <div class="grid9 enabled_disabled">
                                <div class="floatL mr10"><input type="checkbox" id="check4" checked="checked" name="chbox" /></div>
                                <div class="floatL mr10"><input type="checkbox" id="check5" name="chbox1" /></div>
                            </div>
                            <div class="clear"></div>
                        </div>
                            
                        <div class="formRow">
                            <div class="grid3"><label>Usual checkbox: </label></div>
                            <div class="grid9 check">
                                <input type="checkbox" id="check1" checked="checked" name="chbox" />
                                <label for="check1"  class="mr20">Checked</label>
                                
                                <input type="checkbox" id="check2" name="chbox1" />
                                <label for="check2"  class="mr20">Unchecked</label>
                                
                                <input type="checkbox" name="chbox1" id="check3" checked="checked" disabled="disabled" />
                                <label for="check3"  class="mr20 labelDisabled">Disabled</label>
                            </div>
                            <div class="clear"></div>
                        </div>
                                                
                        <div class="formRow">
                            <div class="grid3"><label>Usual radio :</label> </div>
                            <div class="grid9">
                                <input type="radio" id="radio1" name="question1" /><label for="radio1"  class="mr20">Radio</label>
                                <input type="radio" id="radio2" name="question1" checked="checked" /><label for="radio2"  class="mr20">Radio checked</label>
                                <input type="radio" name="question" checked="checked" disabled="disabled" /><label class="labelDisabled">Disabled</label>
                            </div>
                            <div class="clear"></div>
                        </div>
                            
                        <div class="formRow">
                            <div class="grid3"><label>Usual file input :</label> </div>
                            <div class="grid9">
                                <input type="file" class="fileInput" id="fileInput" />
                            </div>
                            <div class="clear"></div>
                        </div>
                            
                        <div class="formRow">
                            <div class="grid3"><label>Simple numbers input:</label></div>
                            <div class="grid9"><input type="text" id="s1" value="10" /></div><div class="clear"></div>
                        </div>
                        
                        <div class="formRow">
                            <div class="grid3"><label>Decimal:</label></div>
                            <div class="grid9"><input type="text" id="s2" value="10.25" /></div><div class="clear"></div>
                        </div>
                        
                        <div class="formRow">
                            <div class="grid3"><label>Currency:</label></div>
                            <div class="grid9"><input type="text" id="s3" /></div><div class="clear"></div>
                        </div>
                        
                        <div class="formRow">
                            <div class="grid3"><label>Inline data:</label></div>
                            <div class="grid9">
                                <ul id="s4">
                                    <li>item 1</li>
                                    <li>item 2</li>
                                    <li>item 3</li>
                                    <li>item 4</li>
                                    <li>item 5</li>
                                    <li>item 6</li>
                                    <li>item 7</li>
                                    <li>item 8</li>
                                    <li>item 9</li>
                                    <li>item 10</li>
                                </ul>
                            </div>
                            <div class="clear"></div>
                        </div>
                            
                        <div class="formRow">
                            <div class="grid3"><label>Inline data (links):</label></div>
                            <div class="grid9"><div id="s5"></div></div><div class="clear"></div>
                        </div>
                    </div>
                </div>
            </fieldset>
        
            <fieldset>
                <div class="widget">
                    <div class="whead"><span class="icon-glass"></span><h6>Multiple selects with filter</h6><div class="clear"></div></div>
                    <div class="body">
                        <div class="leftBox">
                            <input type="text" id="box1Filter" class="boxFilter" placeholder="Filter entries..." /><button type="button" id="box1Clear" class="dualBtn fltr">x</button><br />
                            
                            <select id="box1View" multiple="multiple" class="multiple" style="height:300px;">
                            <option value="501649">2008-2009 "Mini" Baja</option>
                            <option value="501497" selected="selected">AAPA - Asian American Psychological Association</option>
                            <option value="501493">Agape</option>
                            <option value="501562" selected="selected">AGE-Alliance for Graduate Excellence</option>
                            <option value="500676">AICHE (American Inst of Chemical Engineers)</option>
                            <option value="501460">AIDS Sensitivity Awareness Project ASAP</option>
                            <option value="500004">Aikido Club</option>
                            <option value="500336">Akanke</option>
                            </select>
                            <br/>
                            <span id="box1Counter" class="countLabel"></span>
                            
                            <div class="displayNone"><select id="box1Storage"></select></div>
                        </div>
                                
                        <div class="dualControl">
                            <button id="to2" type="button" class="dualBtn mr5 mb15">&nbsp;&gt;&nbsp;</button>
                            <button id="allTo2" type="button" class="dualBtn">&nbsp;&gt;&gt;&nbsp;</button><br />
                            <button id="to1" type="button" class="dualBtn mr5">&nbsp;&lt;&nbsp;</button>
                            <button id="allTo1" type="button" class="dualBtn">&nbsp;&lt;&lt;&nbsp;</button>
                        </div>
                                
                        <div class="rightBox">
                            <input type="text" id="box2Filter" class="boxFilter" placeholder="Filter entries..." /><button type="button" id="box2Clear" class="dualBtn fltr">x</button><br />
                            <select id="box2View" multiple="multiple" class="multiple" style="height:300px;">
                            <option value="501053">Academy of Film Geeks</option>
                            <option value="500001">Accounting Association</option>
                            <option value="501227" selected="selected">ACLU</option>
                            <option value="501610" selected="selected">Active Minds</option>
                            <option value="501514">Activism with A Reel Edge (A.W.A.R.E.)</option>
                            <option value="501656">Adopt a Grandparent Program</option>
                            <option value="501050">Africa Awareness Student Organization</option>
                            <option value="501075">African Diasporic Cultural RC Interns</option>
                            </select><br/>
                            <span id="box2Counter" class="countLabel"></span>
                            
                            <div class="displayNone"><select id="box2Storage"></select></div>
                        </div>
                        <div class="clear"></div>
                    </div>
                </div>
            </fieldset>
        
            <div class="divider"><span></span></div>
        
            <fieldset>
                <div class="widget">
                    <div class="whead"><h6>Full width grid</h6><div class="clear"></div></div>
                    <div class="formRow fluid">
                        <div class="grid12"><input type="text" name="regular" value="grid12" /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6"><input type="text" name="regular" value="grid12" /></div>
                        <div class="grid6"><input type="text" name="regular" value="grid12" /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid4"><input type="text" name="regular" value="grid4" /></div>
                        <div class="grid8"><input type="text" name="regular" value="grid8" /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid8"><input type="text" name="regular" value="grid8" /></div>
                        <div class="grid4"><input type="text" name="regular" value="grid4" /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid4"><input type="text" name="regular" value="grid4" /></div>
                        <div class="grid4"><input type="text" name="regular" value="grid4" /></div>
                        <div class="grid4"><input type="text" name="regular" value="grid4" /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid3"><input type="text" name="g3" value="grid3" /></div>
                        <div class="grid3"><input type="text" name="g3" value="grid3" /></div>
                        <div class="grid3"><input type="text" name="g3" value="grid3" /></div>
                        <div class="grid3"><input type="text" name="g3" value="grid3" /></div>
                        <div class="clear"></div>
                    </div>
                </div>
            </fieldset>
        
            <fieldset>
                <div class="widget fluid">
                    <div class="whead"><h6 id="grid">Grid with labels</h6><div class="clear"></div></div>
                    <div class="formRow">
                        <div class="grid3"><label>Clickable label:</label></div>
                        <div class="grid9">
                            <span class="grid6"><input type="text" name="g6" value="grid6" /></span>
                            <span class="grid6"><input type="text" name="g6" value="grid6" /></span>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Clickable label:</label></div>
                        <div class="grid9">
                            <span class="grid4"><input type="text" name="g4" value="grid4" /></span>
                            <span class="grid8"><input type="text" name="g8" value="grid8" /></span>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Clickable label:</label></div>
                        <div class="grid9">
                            <span class="grid8"><input type="text" name="g8" value="grid8" /></span>
                            <span class="grid4"><input type="text" name="g4" value="grid4" /></span>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Clickable label:</label></div>
                        <div class="grid9">
                            <span class="grid4"><input type="text" name="g4" value="grid4" /></span>
                            <span class="grid4"><input type="text" name="g4" value="grid4" /></span>
                            <span class="grid4"><input type="text" name="g4" value="grid4" /></span>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow">
                        <div class="grid3"><label>Clickable label:</label></div>
                        <div class="grid9">
                            <span class="grid3"><input type="text" name="g3" value="grid3" /></span>
                            <span class="grid3"><input type="text" name="g3" value="grid3" /></span>
                            <span class="grid3"><input type="text" name="g3" value="grid3" /></span>
                            <span class="grid3"><input type="text" name="g3" value="grid3" /></span>
                        </div>
                        <div class="clear"></div>
                    </div>
                </div>
            </fieldset>
        
            <fieldset>
            <div class="fluid">
                <div class="widget grid6 rtl-inputs">
                    <div class="whead"><h6>Grid with labels</h6><div class="clear"></div></div>
                    <div class="formRow"><span class="grid2"><input type="text" name="g8" value="grid2" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid3"><input type="text" name="g8" value="grid3" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid4"><input type="text" name="g4" value="grid4" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid5"><input type="text" name="g3" value="grid5" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid6"><input type="text" name="g3" value="grid6" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid7"><input type="text" name="g3" value="grid7" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid8"><input type="text" name="g3" value="grid8" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid9"><input type="text" name="g3" value="grid9" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid10"><input type="text" name="g3" value="grid10" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid11"><input type="text" name="g3" value="grid11" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid12"><input type="text" name="g3" value="grid12" /></span><div class="clear"></div></div>
                </div>
                <div class="widget grid6">
                    <div class="whead"><h6>Grid with labels</h6><div class="clear"></div></div>
                    <div class="formRow"><span class="grid2"><input type="text" name="g8" value="grid2" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid3"><input type="text" name="g8" value="grid3" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid4"><input type="text" name="g4" value="grid4" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid5"><input type="text" name="g3" value="grid5" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid6"><input type="text" name="g3" value="grid6" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid7"><input type="text" name="g3" value="grid7" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid8"><input type="text" name="g3" value="grid8" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid9"><input type="text" name="g3" value="grid9" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid10"><input type="text" name="g3" value="grid10" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid11"><input type="text" name="g3" value="grid11" /></span><div class="clear"></div></div>
                    <div class="formRow"><span class="grid12"><input type="text" name="g3" value="grid12" /></span><div class="clear"></div></div>
                </div>
            </div>
            </fieldset>
        </div><!-- end controles -->

        <!-- Form Validation -->
<form id="usualValidate" class="main" method="post" action="">
                <fieldset>
                    <div class="widget">
                        <div class="whead"><h6>Usual form validation</h6><div class="clear"></div></div>
                        <div class="formRow">
                            <div class="grid3"><label>Usual field:<span class="req">*</span></label></div>
                            <div class="grid9"><input type="text" class="required" name="firstname" id="firstname"/></div><div class="clear"></div>
                        </div>
                        <div class="formRow">
                            <div class="grid3"><label>With minimum chars:<span class="req">*</span></label></div>
                            <div class="grid9"><input type="text" class="required" name="minChars" id="minChars"/></div><div class="clear"></div>
                        </div>
                        <div class="formRow">
                            <div class="grid3"><label>With maximum chars:<span class="req">*</span></label></div>
                            <div class="grid9"><input type="text" class="required" name="maxChars" id="maxChars"/></div><div class="clear"></div>
                        </div>
                        <div class="formRow">
                            <div class="grid3"><label>With minimum num:<span class="req">*</span></label></div>
                            <div class="grid9"><input type="text" class="required" name="mini" id="mini"/></div><div class="clear"></div>
                        </div>
                        <div class="formRow">
                            <div class="grid3"><label>With maximum num:<span class="req">*</span></label></div>
                            <div class="grid9"><input type="text" class="required" name="maxi" id="maxi"/></div><div class="clear"></div>
                        </div>
                        <div class="formRow">
                            <div class="grid3"><label>With range:<span class="req">*</span></label></div>
                            <div class="grid9"><input type="text" class="required" name="range" id="range"/></div><div class="clear"></div>
                        </div>
                        <div class="formRow">
                            <div class="grid3"><label>Email field:<span class="req">*</span></label></div>
                            <div class="grid9"><input type="text" class="required" name="emailField" id="emailField"/></div><div class="clear"></div>
                        </div>
                        <div class="formRow">
                            <div class="grid3"><label>URL field:<span class="req">*</span></label></div>
                            <div class="grid9"><input type="text" class="required" name="urlField" id="urlField"/></div><div class="clear"></div>
                        </div>
                        <div class="formRow">
                            <div class="grid3"><label>Date field:<span class="req">*</span></label></div>
                            <div class="grid9"><input type="text" class="required" name="dateField" id="dateField"/></div><div class="clear"></div>
                        </div>
                        <div class="formRow">
                            <div class="grid3"><label>Digits only:<span class="req">*</span></label></div>
                            <div class="grid9"><input type="text" class="required" name="digitsOnly" id="digitsOnly"/></div><div class="clear"></div>
                        </div>
                        <div class="formRow">
                            <div class="grid3"><label>Custom error message:<span class="req">*</span></label></div>
                            <div class="grid9"><input type="text" class="required" name="customMessage" id="customMessage"/></div><div class="clear"></div>
                        </div>
                        <div class="formRow">
                            <div class="grid3"><label>Enter password:<span class="req">*</span></label></div>
                            <div class="grid9"><input type="text" class="required" name="enterPass" id="enterPass"/></div><div class="clear"></div>
                        </div>
                        <div class="formRow">
                            <div class="grid3"><label>Repeat password:<span class="req">*</span></label></div>
                            <div class="grid9"><input type="text" class="required" name="repeatPass" id="repeatPass"/></div><div class="clear"></div>
                        </div>
                        <div class="formRow">
                            <div class="grid3"><label>Something from checks:<span class="req">*</span></label></div>
                            <div class="grid9"><input type="checkbox" id="agree" name="agree" class="required check" /><label for="agree">Accept terms?</label></div><div class="clear"></div>
                        </div>
                        <div class="formRow"><input type="submit" value="Submit" class="buttonM bBlack formSubmit" /><div class="clear"></div></div>
                        <div class="clear"></div>
                    </div>
                </fieldset>
            </form>
        <!-- End form validation -->

        <!-- Calendar -->
        <div id="demo_calendar" class="widget">
            <div class="whead"><h6>Calendar</h6><div class="clear"></div></div>
            <div id="calendar"></div>
        </div>
        <!-- End Calendar -->

        <!-- Tables -->
<!-- Standard table -->
        <div class="widget">
            <div class="whead"><h6>Static table</h6><div class="clear"></div></div>
            
            <table cellpadding="0" cellspacing="0" width="100%" class="tDefault">
                <thead>
                    <tr>
                        <td>Column name</td>
                        <td>Column name</td>
                        <td>Column name</td>
                        <td>Column name</td>
                        <td>Column name</td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                </tbody>
            </table>
        </div>
    
        <!-- Table with checkboxes -->
        <div class="widget">
            <div class="whead"><span class="titleIcon check">
            <input type="checkbox" id="titleCheck" name="titleCheck" /></span><h6>Static table with checkboxes</h6><div class="clear"></div></div>
            <table cellpadding="0" cellspacing="0" width="100%" class="tDefault checkAll check" id="checkAll">
              <thead>
                  <tr>
                      <td><img src="~/Content/images/elements/other/tableArrows.png" alt="" /></td>
                      <td>Column name</td>
                      <td>Column name</td>
                      <td>Column name</td>
                      <td>Column name</td>
                      <td>Column name</td>
                  </tr>
              </thead>
              <tbody>
                  <tr>
                      <td><input type="checkbox" id="titleCheck2" name="checkRow" /></td>
                      <td>Row 1</td>
                      <td>Row 2</td>
                      <td>Row 3</td>
                      <td>Row 4</td>
                      <td>Row 5</td>
                  </tr>
                  <tr>
                      <td><input type="checkbox" id="titleCheck3" name="checkRow" /></td>
                      <td>Row 1</td>
                      <td>Row 2</td>
                      <td>Row 3</td>
                      <td>Row 4</td>
                      <td>Row 5</td>
                  </tr>
                  <tr>
                      <td><input type="checkbox" id="titleCheck4" name="checkRow" /></td>
                      <td>Row 1</td>
                      <td>Row 2</td>
                      <td>Row 3</td>
                      <td>Row 4</td>
                      <td>Row 5</td>
                  </tr>
                  <tr>
                      <td><input type="checkbox" id="titleCheck5" name="checkRow" /></td>
                      <td>Row 1</td>
                      <td>Row 2</td>
                      <td>Row 3</td>
                      <td>Row 4</td>
                      <td>Row 5</td>
                  </tr>
                  <tr>
                      <td><input type="checkbox" id="titleCheck6" name="checkRow" /></td>
                      <td>Row 1</td>
                      <td>Row 2</td>
                      <td>Row 3</td>
                      <td>Row 4</td>
                      <td>Row 5</td>
                  </tr>
              </tbody>
            </table>
        </div>
    
        <!-- With some stuff in the head -->
        <div class="widget">
            <div class="whead">
                <h6>Header elements</h6>
                <div class="titleOpt">
                    <a href="#" data-toggle="dropdown"><span class="icos-cog3"></span><span class="clear"></span></a>
                    <ul class="dropdown-menu pull-right">
                            <li><a href="#"><span class="icos-add"></span>Add</a></li>
                            <li><a href="#"><span class="icos-trash"></span>Remove</a></li>
                            <li><a href="#" class=""><span class="icos-pencil"></span>Edit</a></li>
                            <li><a href="#" class=""><span class="icos-heart"></span>Do whatever you like</a></li>
                    </ul>
                </div>
                <div class="clear"></div>
            </div>
            <table cellpadding="0" cellspacing="0" width="100%" class="tDefault">
                <thead>
                    <tr>
                        <td>Column name</td>
                        <td>Column name</td>
                        <td>Column name</td>
                        <td>Column name</td>
                        <td>Column name</td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                </tbody>
            </table>
        </div>
    
    	<!-- Table inside tabs -->
        <div class="widget tableTabs"> 
            <div class="whead"><h6>Static table with tabs</h6><div class="clear"></div></div>      
            <ul class="tabs">
                <li><a href="#ttab1">Tab active</a></li>
                <li><a href="#ttab2">Tab inactive</a></li>
            </ul>
            <div class="tab_container">
                <div id="ttab1" class="tab_content">
                    <table cellpadding="0" cellspacing="0" width="100%" class="tDefault">
                        <thead>
                            <tr>
                                <td>Column name</td>
                                <td>Column name</td>
                                <td>Column name</td>
                                <td>Column name</td>
                                <td>Column name</td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Row 1</td>
                                <td>Row 2</td>
                                <td>Row 3</td>
                                <td>Row 4</td>
                                <td>Row 5</td>
                            </tr>
                            <tr>
                                <td>Row 1</td>
                                <td>Row 2</td>
                                <td>Row 3</td>
                                <td>Row 4</td>
                                <td>Row 5</td>
                            </tr>
                            <tr>
                                <td>Row 1</td>
                                <td>Row 2</td>
                                <td>Row 3</td>
                                <td>Row 4</td>
                                <td>Row 5</td>
                            </tr>
                            <tr>
                                <td>Row 1</td>
                                <td>Row 2</td>
                                <td>Row 3</td>
                                <td>Row 4</td>
                                <td>Row 5</td>
                            </tr>
                            <tr>
                                <td>Row 1</td>
                                <td>Row 2</td>
                                <td>Row 3</td>
                                <td>Row 4</td>
                                <td>Row 5</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div id="ttab2" class="tab_content">
                    <table cellpadding="0" cellspacing="0" width="100%" class="tDefault">
                        <thead>
                            <tr>
                                <td>Column name</td>
                                <td>Column name</td>
                                <td>Column name</td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Row 1</td>
                                <td>Row 2</td>
                                <td>Row 3</td>
                            </tr>
                            <tr>
                                <td>Row 1</td>
                                <td>Row 2</td>
                                <td>Row 3</td>
                            </tr>
                            <tr>
                                <td>Row 1</td>
                                <td>Row 2</td>
                                <td>Row 3</td>
                            </tr>
                            <tr>
                                <td>Row 1</td>
                                <td>Row 2</td>
                                <td>Row 3</td>
                            </tr>
                            <tr>
                                <td>Row 1</td>
                                <td>Row 2</td>
                                <td>Row 3</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>	
            <div class="clear"></div>		 
        </div>
    
        <div class="divider"><span></span></div>
    	
        <!-- Table without thead -->
        <div class="widget justTable">
            <table cellpadding="0" cellspacing="0" width="100%" class="tDefault">
                <tbody>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                </tbody>
            </table>
        </div>
    
        <div class="divider"><span></span></div>
    	
        <!-- Table with rowspans and colspans -->
        <div class="widget justTable">
            <table cellpadding="0" cellspacing="0" width="100%" class="tDefault">
              <tbody>
                  <tr>
                      <td colspan="2" align="center">Colspan</td>
                      <td>Row 2</td>
                      <td>Row 3</td>
                      <td rowspan="3" align="center" valign="middle">Rowspan</td>
                      <td>Row 5</td>
                  </tr>
                  <tr>
                      <td>Row 1</td>
                      <td>Row 1</td>
                      <td colspan="2" align="center">Colspan</td>
                      <td rowspan="3" align="center" valign="middle">Rowspan</td>
                  </tr>
                  <tr>
                      <td colspan="2" align="center">Colspan</td>
                      <td>Row 2</td>
                      <td>Row 3</td>
                  </tr>
                  <tr>
                      <td>Row 1</td>
                      <td>Row 1</td>
                      <td colspan="2" align="center">Colspan</td>
                      <td>Row 4</td>
                  </tr>
                  <tr>
                      <td colspan="2" align="center">Colspan</td>
                      <td>Row 2</td>
                      <td>Row 3</td>
                      <td>Row 4</td>
                      <td>Row 5</td>
                  </tr>
              </tbody>
            </table>
        </div>
    
        <div class="divider"><span></span></div>
    	
        <!-- Simple light table -->
        <div class="widget">
            <table cellpadding="0" cellspacing="0" width="100%" class="tLight noBorderT">
                <thead>
                    <tr>
                        <td>Column name</td>
                        <td>Column name</td>
                        <td>Column name</td>
                        <td>Column name</td>
                        <td>Column name</td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                </tbody>
            </table>
        </div>
    
        <div class="divider"><span></span></div>
    	
        <!-- Simple head with dark head -->
        <div class="widget">
            <table cellpadding="0" cellspacing="0" width="100%" class="tDark">
                <thead>
                    <tr>
                        <td>Column name</td>
                        <td>Column name</td>
                        <td>Column name</td>
                        <td>Column name</td>
                        <td>Column name</td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                    <tr>
                        <td>Row 1</td>
                        <td>Row 2</td>
                        <td>Row 3</td>
                        <td>Row 4</td>
                        <td>Row 5</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <!-- End Tables -->

        <!-- Editor -->
        <div class="widget">
            <div class="whead"><h6>WYSIWYG editor</h6><div class="clear"></div></div>
            <textarea id="editor" name="editor" rows="" cols="16">Some cool stuff here</textarea>
        </div>
        <!-- End Editor -->
        
        <!-- Uploader -->
        <div class="widget">    
            <div class="whead"><h6>Multiple files uploader</h6><div class="clear"></div></div>
            <div id="uploader">You browser doesn't have HTML 4 support.</div>                    
        </div>
        <!-- End Uploader -->

        <!-- Form Wizard -->
            <!-- Wizard with custom fields validation -->
            <div class="widget">
                <div class="whead"><h6>Wizard with custom fields validation</h6><div class="clear"></div></div>
                <form id="wizard2" method="post" action="submit.html" class="main">
                    <fieldset class="step" id="w2first">
                        <h1>First step description</h1>
                        <div class="formRow">
                            <div class="grid3"><label>Username:<span class="req">*</span></label></div>
                            <div class="grid9"><input type="text" name="bazinga" /></div>
                            <div class="clear"></div>
                        </div>
                        <div class="formRow">
                            <div class="grid3"><label>Password:</label></div>
                            <div class="grid9"><input type="password" name="pw1" id="pw1" /></div>
                            <div class="clear"></div>
                        </div>
                        <div class="formRow">
                            <div class="grid3"><label>Email:<span class="req">*</span></label></div>
                            <div class="grid9"><input type="text" name="email" /></div>
                            <div class="clear"></div>
                        </div>
                    </fieldset>
                    <fieldset id="w2confirmation" class="step">
                        <h1>Second step description</h1>
                        <div class="formRow">
                            <div class="grid3"><label>Your city:</label></div>
                            <div class="grid9"><input type="text" name="city1" id="city1" /></div>
                            <div class="clear"></div>
                        </div>
                        <div class="formRow">
                            <div class="grid3"><label>Something more:</label></div>
                            <div class="grid9"><input type="text" name="smth1" id="smth1" /></div>
                            <div class="clear"></div>
                        </div>
                    </fieldset>
                    <div class="formRow">
                        <div class="status" id="status2"></div>
                        <div class="formSubmit">

                            <input class="buttonM bDefault" id="back2" value="Back" type="reset" />
                            <input class="buttonM bRed ml10" id="next2" value="Next" type="submit" />
                            <div class="clear"></div>
                        </div>
                        <div class="clear"></div>
                    </div>
                </form>
                <div class="data" id="w2"></div>
            </div>
        <!-- End Form Wizard -->

        <!-- UI -->

        <div class="fluid">
        	
            <!-- Sliders -->
            <div class="widget">
                <div class="whead"><h6>Sliders</h6><div class="clear"></div></div>
                <div class="formRow">
                    <div class="grid3"><label>Simple slider:</label></div>
                    <div class="grid9"><div class="uSlider"></div></div><div class="clear"></div>
                </div>
                
                <div class="formRow">
                    <div class="grid3"><label>Range slider:</label></div>
                    <div class="grid9">
                        <div class="sliderSpecs">
                            <label for="rangeAmount">Price range:</label><input type="text" id="rangeAmount" />
                            <div class="clear"></div>
                        </div>
                        <div class="uRange"></div>
                    </div>
                    <div class="clear"></div>
                </div>		
                
                <div class="formRow">
                    <div class="grid3"><label>With minimum:</label></div>
                    <div class="grid9">
                        <div class="sliderSpecs">
                            <label for="minRangeAmount">Minimum:</label><input type="text" id="minRangeAmount" />
                            <div class="clear"></div>
                        </div>
                        <div class="uMin"></div>
                    </div>
                    <div class="clear"></div>
                </div>	
                
                <div class="formRow">
                    <div class="grid3"><label>With maximum:</label></div>
                    <div class="grid9">
                        <div class="sliderSpecs">
                            <label for="maxRangeAmount">Maximum:</label><input type="text" id="maxRangeAmount" />
                            <div class="clear"></div>
                        </div>
                        <div class="uMax"></div>
                    </div>
                    <div class="clear"></div>
                </div>
                
                <div class="formRow">
                    <div class="grid3"><label>Vertical sliders:</label></div>
                    <div class="grid9">
                        <div id="eq">
                            <span>88</span>
                            <span>77</span>
                            <span>55</span>
                            <span>33</span>
                            <span>40</span>
                            <span>45</span>
                            <span>70</span>
                            <span>82</span>
                        </div>    
                    </div>
                    <div class="clear"></div>
                </div>
            </div>
        
        	<!-- Progress bars -->
            <div class="widget">
                <div class="whead"><h6>Progress bars</h6><div class="clear"></div></div>
                <div class="formRow">
                    <div class="grid3"><label>jQuery UI bar:</label></div>
                    <div class="grid9">
                        <div id="progress"></div>
                    </div>
                    <div class="clear"></div>
                </div>
        
                <div class="formRow">
                    <div class="grid3"><label>Animated bar:</label></div>
                    <div class="grid9">
                        <div id="progress1"><span class="pbar"></span><span class="percent"></span><span class="elapsed"></span></div>
                    </div>
                    <div class="clear"></div>
                </div>
                
                <div class="formRow">
                    <div class="grid3"><label>Progress with delay:</label></div>
                    <div class="grid9">
                        <div id="progress2"><span class="pbar"></span><span class="percent"></span><span class="elapsed"></span></div>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>
        
        	<!-- Animated progress bars with tooltips -->
            <div class="widget">
                <div class="whead"><h6>Animated bars with tooltips</h6><div class="clear"></div></div>
                
                <div class="formRow">
                    <div class="grid3"><label>Grey:</label></div>
                    <div class="grid9">
                        <div class="contentProgress mt8"><div class="barGr tipS" id="bar1" title="15%"></div></div>
                    </div>
                    <div class="clear"></div>
                </div>
                
                <div class="formRow">
                    <div class="grid3"><label>Blue:</label></div>
                    <div class="grid9">
                        <div class="contentProgress mt8"><div class="barB tipS" id="bar2" title="30%"></div></div>
                    </div>
                    <div class="clear"></div>
                </div>
        
                <div class="formRow">
                    <div class="grid3"><label>Orange:</label></div>
                    <div class="grid9">
                        <div class="contentProgress mt8"><div class="barO tipS" id="bar3" title="45%"></div></div>
                    </div>
                    <div class="clear"></div>
                </div>
        
                <div class="formRow">
                    <div class="grid3"><label>Black:</label></div>
                    <div class="grid9">
                        <div class="contentProgress mt8"><div class="barBl tipS" id="bar4" title="60%"></div></div>
                    </div>
                    <div class="clear"></div>
                </div>
        
                <div class="formRow">
                    <div class="grid3"><label>Red:</label></div>
                    <div class="grid9">
                        <div class="contentProgress mt8"><div class="barR tipS" id="bar5" title="75%"></div></div>
                    </div>
                    <div class="clear"></div>
                </div>
        
                <div class="formRow">
                    <div class="grid3"><label>Green:</label></div>
                    <div class="grid9">
                        <div class="contentProgress mt8"><div class="barG tipS" id="bar6" title="90%"></div></div>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>
        
        
            <div class="fluid">
            
            	<!-- Pickers -->
                <div class="widget grid6">
                    <div class="whead"><h6>Pickers</h6><div class="clear"></div></div>
                    <div class="formRow">
                        <div class="grid3"><label>Inline date picker:</label></div>
                        <div class="grid9"><div class="inlinedate"></div></div><div class="clear"></div>
                    </div>		
                    
                    <div class="formRow">
                        <div class="grid3"><label>Date picker:</label></div>
                        <div class="grid9"><input type="text" class="datepicker" /></div><div class="clear"></div>
                    </div>
                    
                    <div class="formRow">
                        <div class="grid3"><label>Time picker:</label></div>
                        <div class="grid9"><input type="text" class="timepicker" size="10" /><span class="ui-datepicker-append">Use mousewheel and keyboard</span></div><div class="clear"></div>
                    </div>
                    
                    <div class="formRow">
                        <div class="grid3"><label>Time range:</label></div>
                        <div class="grid9">
                            <ul class="timeRange">
                                <li><input type="text" class="timepicker" size="10" /></li>
                                <li class="sep">-</li>
                                <li><input type="text" class="timepicker" size="10" /></li>
                            </ul>
                        </div>
                        <div class="clear"></div>
                    </div>
                    
                    <div class="formRow">
                        <div class="grid3"><label>Dates range:</label></div>
                        <div class="grid9">
                            <ul class="datesRange">
                                <li><input type="text" id="fromDate" name="from" placeholder="From"/></li>
                                <li class="sep">-</li>
                                <li><input type="text" id="toDate" name="to" placeholder="To"/></li>
                            </ul>
                        </div><div class="clear"></div>
                    </div>
                    
                    <div class="formRow">
                        <div class="grid3"><label>Color picker:</label></div>
                        <div class="grid9"><div class="cPicker" id="cPicker"><div style="background-color: #e62e90"></div><span>Choose color...</span></div></div><div class="clear"></div>
                    </div>
                    
                    <div class="formRow hideTablet">
                        <div class="grid3"><label>Flat color picker:</label></div>
                        <div class="grid9"><div class="cPicker" id="flatPicker"></div></div><div class="clear"></div>
                    </div>
                </div>
                
                <!-- Other stuff -->
                <div class="grid6">
                    <div class="widget">
                        <div class="whead"><h6>Growl notifications</h6><div class="clear"></div></div>
                        <div class="body" align="center">
                            <input type="button" value="Basic notice" class="buttonM bDefault" style="margin: 5px;" onclick="$.jGrowl('Hello world!');" />
                            <input type="button" value="Sticky notice" class="buttonM bDefault" style="margin: 5px;" onclick="$.jGrowl('Stick this!', { sticky: true });"  />
                            <input type="button" value="Message with header" class="buttonM bDefault" style="margin: 5px;" onclick="$.jGrowl('A message with a header', { header: 'Important' });" />
                            <input type="button" value="Long live message" class="buttonM bDefault" style="margin: 5px;" onclick="$.jGrowl('A message that will live a little longer.', { life: 10000 });"  />
                        </div>
                    </div>		
                    
                    <!-- Ajax loaders -->
                    <div class="widget">
                        <div class="whead"><h6>Ajax loaders</h6><div class="clear"></div></div>
                        <div class="body" align="center">
                            <div class="mr20 floatL"><img src="~/Content/images/elements/loaders/1.gif" style="float: left" alt="" /><img src="~/Content/images/elements/loaders/1s.gif" style="float: left; margin: 7px 0 0 10px;" alt="" /><div class="clear"></div></div>
                            <div class="mr20 floatL"><img src="~/Content/images/elements/loaders/2.gif" style="float: left" alt="" /><img src="~/Content/images/elements/loaders/2s.gif" style="float: left; margin: 7px 0 0 10px;" alt="" /><div class="clear"></div></div>
                            <div class="mr20 floatL"><img src="~/Content/images/elements/loaders/3.gif" style="float: left" alt="" /><img src="~/Content/images/elements/loaders/3s.gif" style="float: left; margin: 7px 0 0 10px;" alt="" /><div class="clear"></div></div>
                            <div class="mr20 floatL"><img src="~/Content/images/elements/loaders/4.gif" style="float: left" alt="" /><img src="~/Content/images/elements/loaders/4s.gif" style="float: left; margin: 7px 0 0 10px;" alt="" /><div class="clear"></div></div>
                            <div class="mr20 floatL"><img src="~/Content/images/elements/loaders/5.gif" style="float: left" alt="" /><img src="~/Content/images/elements/loaders/5s.gif" style="float: left; margin: 7px 0 0 10px;" alt="" /><div class="clear"></div></div>
                            <div class="mr20 floatL"><img src="~/Content/images/elements/loaders/6.gif" style="float: left" alt="" /><img src="~/Content/images/elements/loaders/6s.gif" style="float: left; margin: 7px 0 0 10px;" alt="" /><div class="clear"></div></div>
                            <div class="mr20 floatL"><img src="~/Content/images/elements/loaders/7.gif" style="float: left; margin-top: 9px;" alt="" /><img src="~/Content/images/elements/loaders/7s.gif" style="float: left; margin: 12px 0 0 10px;" alt="" /><div class="clear"></div></div>
                            <div class="mr20 floatL"><img src="~/Content/images/elements/loaders/8.gif" style="float: left" alt="" /><img src="~/Content/images/elements/loaders/8s.gif" style="float: left; margin: 7px 0 0 10px;" alt="" /><div class="clear"></div></div>
                            <div class="mr20 floatL"><img src="~/Content/images/elements/loaders/9.gif" style="float: left" alt="" /><img src="~/Content/images/elements/loaders/9s.gif" style="float: left; margin: 7px 0 0 10px;" alt="" /><div class="clear"></div></div>
                            <div class="mr20 floatL"><img src="~/Content/images/elements/loaders/10.gif" style="float: left" alt="" /><img src="~/Content/images/elements/loaders/10s.gif" style="float: left; margin: 7px 0 0 10px;" alt="" /><div class="clear"></div></div>
                            <div class="clear"></div>
                        </div>
                    </div>	
                    
                    <!-- Collapsible. Opened by default -->
                    <div class="widget">
                        <div class="whead hand opened" id="opened"><h6>Toggle. Opened by default</h6><div class="clear"></div></div>
                        <div class="body">This one is opened by default</div>
                    </div>
                    
                    <!-- Collapsible. Closed by default -->
                    <div class="widget">
                        <div class="whead hand closed"><h6>Toggle. Closed by default</h6><div class="clear"></div></div>
                        <div class="body">This one is closed by default</div>
                    </div>
                    
                    <!-- Accordion -->
                    <div class="widget acc">      
                      <div class="whead"><h6>Accordion menu. Active</h6><div class="clear"></div></div>
                        <div class="menu_body">
                            This is an accordion. This one is collapsible and opened by default
                        </div>
                      <div class="whead"><h6>Accordion menu. Inactive</h6><div class="clear"></div></div>
                        <div class="menu_body">
                            Now this one is active
                        </div>
                      <div class="whead"><h6>Accordion menu. Inactive</h6><div class="clear"></div></div>
                        <div class="menu_body">
                            And now this one...
                       </div>
                    </div>  
                    
                    <!-- Toggles group -->
                    <div class="widget togglesGroup">
                        <div class="whead opened" id="toggleOpened"><h6>Toggles group. Active</h6><div class="clear"></div></div>
                        <div class="body">This widget is opened by default. Works in case of adding id="opened" to the widget head</div>
                        
                        <div class="whead closed"><h6>Toggles group. Inactive</h6><div class="clear"></div></div>
                        <div class="body">This widget is closed by default.</div>
                        
                        <div class="whead closed"><h6>Toggles group. Inactive</h6><div class="clear"></div></div>
                        <div class="body">This widget is closed by default.</div>
                    </div>
                </div>
            </div>
        
            <!-- Notifications -->
            <div class="nNote nWarning">
                <p>This is a warning message. You can use this to warn users on any events</p>
            </div>
            <div class="nNote nInformation">
                <p>This is a message for information, can be any general information.</p>
            </div>   
            <div class="nNote nSuccess">
                <p>Success message! hoooraaay!!!!</p>
            </div>  
            <div class="nNote nFailure">
                <p>Oops sorry. That action is not valid, or our servers have gone bonkers</p>
            </div>
        
            <!-- Pagination -->
            <div class="pagination">
                <ul class="pages">
                    <li class="prev"><a href="#">&lt;</a></li>
                    <li><a href="#" class="active">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li>...</li>
                    <li><a href="#">30</a></li>
                    <li class="next"><a href="#">&gt;</a></li>
                </ul>
            </div>

        	<!-- Dialogs and stuff -->
            <div class="fluid">
                <div class="widget grid6">
                    <div class="whead"><h6>Dialogs</h6><div class="clear"></div></div>
                    <div class="body" align="center">
                        <a href="#" class="buttonM bDefault" id="dialog_open">jQuery UI dialog</a>
                        <!-- ui-dialog -->
                        <div id="dialog" title="Dialog Title">
                              <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                        </div>
                        <a href="#" class="buttonM bDefault ml10" id="modal_open">Open modal</a>
                        <div id="dialog-modal" title="Basic modal dialog">
                            <p>Adding the modal overlay screen makes the dialog look more prominent because it dims out the page content.</p>
                        </div>
                        <a href="#" class="buttonM bDefault ml10" id="formDialog_open">Dialog with form elements</a>
                        
                        <!-- Dialog content -->
                        <div id="formDialog" class="dialog" title="Dialog with form elements">
                            <form action="">
                            <label>Text field:</label>
                                <input type="text" name="sampleInput" class="clear" placeholder="Enter something" />
                                <div class="divider"><span></span></div>
                                <div class="dialogSelect m10">
                                    <label>Select:</label>
                                    <select name="select2" >
                                        <option value="opt1">Usual select box</option>
                                        <option value="opt2">Option 2</option>
                                        <option value="opt3">Option 3</option>
                                        <option value="opt4">Option 4</option>
                                        <option value="opt5">Option 5</option>
                                        <option value="opt6">Option 6</option>
                                        <option value="opt7">Option 7</option>
                                        <option value="opt8">Option 8</option>
                                    </select>
                                </div>
                                <div class="divider"><span></span></div>
                                <label>Textarea:</label>
                                <textarea rows="8" cols="" name="textarea" class="auto" placeholder="This textarea is elastic"></textarea>
                                <div>
                                    <span class="floatL"><input type="radio" name="dialogRadio" /><label>Radio</label></span>
                                    <span class="floatR"><input type="checkbox" class="check" name="dialogCheck" checked="checked" /><label>Checkbox</label></span>
                                    <span class="clear"></span>
                                </div>
                            </form>
                        </div>
                        
                        <!-- Dialog content -->
                        <a href="#" class="buttonM bDefault ml10" id="customDialog_open">Dialog with custom elements</a>
                        <div id="customDialog" class="customDialog" title="Dialog with other custom elements">
                            <table cellpadding="0" cellspacing="0" width="100%" class="tDefault checkAll tMedia" id="checkAll">
                                <thead>
                                    <tr>
                                        <td width="50">Image</td>
                                        <td class="sortCol"><div>Description<span></span></div></td>
                                        <td width="130" class="sortCol"><div>Date<span></span></div></td>
                                        <td width="120">File info</td>
                                        <td width="100">Actions</td>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <td colspan="5">
                                            <div class="itemActions">
                                                <label>Apply action:</label>
                                                <select>
                                                    <option value="">Select action...</option>
                                                    <option value="Edit">Edit</option>
                                                    <option value="Delete">Delete</option>
                                                    <option value="Move">Move somewhere</option>
                                                </select>
                                            </div>
                                            <div class="tPages">
                                                <ul class="pages">
                                                    <li class="prev"><a href="#" title=""><span class="icon-arrow-14"></span></a></li>
                                                    <li><a href="#" title="" class="active">1</a></li>
                                                    <li><a href="#" title="">2</a></li>
                                                    <li><a href="#" title="">3</a></li>
                                                    <li><a href="#" title="">4</a></li>
                                                    <li><a href="#" title="">5</a></li>
                                                    <li><a href="#" title="">6</a></li>
                                                    <li>...</li>
                                                    <li><a href="#" title="">20</a></li>
                                                    <li class="next"><a href="#" title=""><span class="icon-arrow-17"></span></a></li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                </tfoot>
                                <tbody>
                                    <tr>
                                        <td><a href="~/Content/images/big.png" title="" class="lightbox"><img src="~/Content/images/live/face1.png" alt="" /></a></td>
                                        <td class="textL"><a href="#" title="">Image1 description</a></td>
                                        <td>Feb 12, 2012. 12:28</td>
                                        <td class="fileInfo"><span><strong>Size:</strong> 215 Kb</span><span><strong>Format:</strong> .jpg</span></td>
                                        <td>
                                            <a href="#" class="tablectrl_small bDefault tipS" title="Edit"><span class="iconb" data-icon="&#xe1db;"></span></a>
                                            <a href="#" class="tablectrl_small bDefault tipS" title="Remove"><span class="iconb" data-icon="&#xe136;"></span></a>
                                            <a href="#" class="tablectrl_small bDefault tipS" title="Options"><span class="iconb" data-icon="&#xe1f7;"></span></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><a href="~/Content/images/big.png" title="" class="lightbox"><img src="~/Content/images/live/face1.png" alt="" /></a></td>
                                        <td class="textL"><a href="#" title="">Image1 description</a></td>
                                        <td>Feb 12, 2012. 12:28</td>
                                        <td class="fileInfo"><span><strong>Size:</strong> 215 Kb</span><span><strong>Format:</strong> .jpg</span></td>
                                        <td>
                                            <a href="#" class="tablectrl_small bDefault tipS" title="Edit"><span class="iconb" data-icon="&#xe1db;"></span></a>
                                            <a href="#" class="tablectrl_small bDefault tipS" title="Remove"><span class="iconb" data-icon="&#xe136;"></span></a>
                                            <a href="#" class="tablectrl_small bDefault tipS" title="Options"><span class="iconb" data-icon="&#xe1f7;"></span></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><a href="~/Content/images/big.png" title="" class="lightbox"><img src="~/Content/images/live/face1.png" alt="" /></a></td>
                                        <td class="textL"><a href="#" title="">Image1 description</a></td>
                                        <td>Feb 12, 2012. 12:28</td>
                                        <td class="fileInfo"><span><strong>Size:</strong> 215 Kb</span><span><strong>Format:</strong> .jpg</span></td>
                                        <td>
                                            <a href="#" class="tablectrl_small bDefault tipS" title="Edit"><span class="iconb" data-icon="&#xe1db;"></span></a>
                                            <a href="#" class="tablectrl_small bDefault tipS" title="Remove"><span class="iconb" data-icon="&#xe136;"></span></a>
                                            <a href="#" class="tablectrl_small bDefault tipS" title="Options"><span class="iconb" data-icon="&#xe1f7;"></span></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><a href="~/Content/images/big.png" title="" class="lightbox"><img src="~/Content/images/live/face1.png" alt="" /></a></td>
                                        <td class="textL"><a href="#" title="">Image1 description</a></td>
                                        <td>Feb 12, 2012. 12:28</td>
                                        <td class="fileInfo"><span><strong>Size:</strong> 215 Kb</span><span><strong>Format:</strong> .jpg</span></td>
                                        <td>
                                            <a href="#" class="tablectrl_small bDefault tipS" title="Edit"><span class="iconb" data-icon="&#xe1db;"></span></a>
                                            <a href="#" class="tablectrl_small bDefault tipS" title="Remove"><span class="iconb" data-icon="&#xe136;"></span></a>
                                            <a href="#" class="tablectrl_small bDefault tipS" title="Options"><span class="iconb" data-icon="&#xe1f7;"></span></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><a href="~/Content/images/big.png" title="" class="lightbox"><img src="~/Content/images/live/face1.png" alt="" /></a></td>
                                        <td class="textL"><a href="#" title="">Image1 description</a></td>
                                        <td>Feb 12, 2012. 12:28</td>
                                        <td class="fileInfo"><span><strong>Size:</strong> 215 Kb</span><span><strong>Format:</strong> .jpg</span></td>
                                        <td>
                                            <a href="#" class="tablectrl_small bDefault tipS" title="Edit"><span class="iconb" data-icon="&#xe1db;"></span></a>
                                            <a href="#" class="tablectrl_small bDefault tipS" title="Remove"><span class="iconb" data-icon="&#xe136;"></span></a>
                                            <a href="#" class="tablectrl_small bDefault tipS" title="Options"><span class="iconb" data-icon="&#xe1f7;"></span></a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                
                <!-- Tooltips -->
                <div class="widget grid6">
                    <div class="whead"><h6>Tooltips</h6><div class="clear"></div></div>
                    <div class="body" align="center">
                        <a href="#" class="buttonM bDefault tipN" title="Bottom position">Bottom position</a>
                        <a href="#" class="buttonM bDefault ml10 tipS" title="Top position">Top position</a>
                        <a href="#" class="buttonM bDefault ml10 tipE" title="Left position">Left position</a>
                        <a href="#" class="buttonM bDefault ml10 tipW" title="Right position">Right position</a>
                        <a href="#" class="buttonM bDefault ml10 tipS wHtml" title="this <i>contains</i> <b>formatted</b> <u>text</u>">With HTML inside</a>
                    </div>
                </div>
            </div>
        	
       
    		<!-- Tabs -->
            <div class="fluid">
                <div class="widget grid6">       
                    <ul class="tabs">
                        <li><a href="#tabb1">Tab active</a></li>
                        <li><a href="#tabb2">Tab inactive</a></li>
                    </ul>
                    
                    <div class="tab_container">
                        <div id="tabb1" class="tab_content">
                            Tab is active and has left tabs             
                        </div>
                        <div id="tabb2" class="tab_content"> This tab is active now</div>
                    </div>	
                    <div class="clear"></div>		 
                </div>
                    
                <div class="widget grid6 rightTabs">       
                    <ul class="tabs">
                        <li><a href="#tabb3">Tab active</a></li>
                        <li><a href="#tabb4">Tab inactive</a></li>
                    </ul>
                    <div class="tab_container">
                        <div id="tabb3" class="tab_content">
                            Tab is active and has right tabs               
                        </div>
                        <div id="tabb4" class="tab_content"> This tab is active now</div>
                    </div>	
                    <div class="clear"></div>		 
                </div>
            </div>
        </div>
        <!-- UI -->

        <!-- Icons (images) -->
        <div class="widget">
            <div class="whead"><h6>Icons 14x14</h6><div class="clear"></div></div>
            <div class="body">
            	<div style="text-align: center;">
                    
                    <span class="icos-cross"></span>
                    <span class="icos-photos"></span>
                    <span class="icos-download"></span>
                    <span class="icos-signal"></span>
                    <span class="icos-music"></span>
                    <span class="icos-transfer"></span>
                    <span class="icos-fullscreen"></span>
                    <span class="icos-full2"></span>
                    <span class="icos-play2"></span>
                    <span class="icos-star"></span>
                    <span class="icos-check"></span>
                    <span class="icos-stats"></span>
                    <span class="icos-stop"></span>
                    <span class="icos-bright"></span>
                    <span class="icos-block"></span>
                    <span class="icos-drive"></span>
                	<span class="icos-dialog"></span>
                    <span class="icos-add"></span>
                    <span class="icos-view"></span>
                    <span class="icos-download3"></span>
                    <span class="icos-play"></span>
                    <span class="icos-logoff"></span>
                    <span class="icos-switcher"></span>
                    <span class="icos-heart"></span>
                    <span class="icos-graph"></span>
                    <span class="icos-chart8"></span>
                    <span class="icos-chart7"></span>
                    <span class="icos-chart6"></span>
                    <span class="icos-chart5"></span>
                    <span class="icos-chart4"></span>
                    <span class="icos-chart3"></span>
                    <span class="icos-chart2"></span>
                	<span class="icos-chart"></span>
                    <span class="icos-vcard"></span>
                    <span class="icos-address-book"></span>
                    <span class="icos-excel"></span>
                    <span class="icos-powerpoint"></span>
                    <span class="icos-zipfiles"></span>
                    <span class="icos-zipfile"></span>
                    <span class="icos-word"></span>
                    <span class="icos-pdf"></span>
                    <span class="icos-documents"></span>
                    <span class="icos-document"></span>
                    <span class="icos-marker"></span>
                    <span class="icos-signpost"></span>
                    <span class="icos-gmaps"></span>
                    <span class="icos-map"></span>
                    <span class="icos-ruler2"></span>
                	<span class="icos-abacus"></span>
                    <span class="icos-ruler"></span>
                    <span class="icos-eyedropper"></span>
                    <span class="icos-scissors"></span>
                    <span class="icos-clipboard"></span>
                    <span class="icos-pencil"></span>
                    <span class="icos-bigbrush"></span>
                    <span class="icos-fountain-pen"></span>
                    <span class="icos-smallbrush"></span>
                    <span class="icos-paintbrush"></span>
                    <span class="icos-electroplug"></span>
                    <span class="icos-electroinput"></span>
                    <span class="icos-power"></span>
                    <span class="icos-battery"></span>
                    <span class="icos-batteryfull"></span>
                    <span class="icos-phonehook"></span>
                    
                    <span class="icos-phone3"></span>
                    <span class="icos-phone"></span>
                    <span class="icos-speech4"></span>
                    <span class="icos-speech3"></span>
                    <span class="icos-speech2"></span>
                    <span class="icos-speech"></span>
                    <span class="icos-repeat"></span>
                    <span class="icos-inbox"></span>
                    <span class="icos-outbox"></span>
                    <span class="icos-inbox2"></span>
                    <span class="icos-wifi2"></span>
                	<span class="icos-wifi"></span>
                    <span class="icos-bluetooth"></span>
                    <span class="icos-bluetooth2"></span>
                    <span class="icos-mobile"></span>
                    <span class="icos-android"></span>
                    <span class="icos-blackberry"></span>
                    <span class="icos-iphone"></span>
                    <span class="icos-full3"></span>
                    <span class="icos-full4"></span>
                    <span class="icos-full5"></span>
                    <span class="icos-recycle"></span>
                    <span class="icos-refresh4"></span>
                    <span class="icos-refresh3"></span>
                    <span class="icos-shuffle"></span>
                    <span class="icos-refresh2"></span>
                    <span class="icos-refresh"></span>
                	<span class="icos-arrowdown"></span>
                    <span class="icos-arrowup"></span>
                    <span class="icos-arrowleft"></span>
                    <span class="icos-arrowright"></span>
                    <span class="icos-drupal"></span>
                    <span class="icos-joomla"></span>
                    <span class="icos-expression"></span>
                    <span class="icos-wordpress2"></span>
                    <span class="icos-wordpress"></span>
                    <span class="icos-blocks"></span>
                    <span class="icos-listimg"></span>
                    <span class="icos-list"></span>
                    <span class="icos-list2"></span>
                    <span class="icos-coverflow"></span>
                    <span class="icos-frames"></span>
                    <span class="icos-fax"></span>
                    
                    <span class="icos-cashreg"></span>
                    <span class="icos-calc"></span>
                    <span class="icos-camera"></span>
                    <span class="icos-ipad"></span>
                    <span class="icos-inano"></span>
                    <span class="icos-iclassic"></span>
                    <span class="icos-monitor"></span>
                    <span class="icos-camera2"></span>
                    <span class="icos-camera3"></span>
                    <span class="icos-wired-mouse"></span>
                    <span class="icos-mighty-mouse"></span>
                	<span class="icos-magic-mouse"></span>
                    <span class="icos-laptop"></span>
                    <span class="icos-imac"></span>
                    <span class="icos-tv"></span>
                    <span class="icos-radio"></span>
                    <span class="icos-printer"></span>
                    <span class="icos-headphones"></span>
                    <span class="icos-mic"></span>
                    <span class="icos-filmstrip2"></span>
                    <span class="icos-filmstrip"></span>
                    <span class="icos-megaphone"></span>
                    <span class="icos-sound"></span>
                    <span class="icos-images"></span>
                    <span class="icos-images2"></span>
                    <span class="icos-images3"></span>
                    <span class="icos-images4"></span>
                	<span class="icos-cassette"></span>
                    <span class="icos-cd"></span>
                    <span class="icos-record"></span>
                    <span class="icos-bluray"></span>
                    <span class="icos-dvd"></span>
                    <span class="icos-sd3"></span>
                    <span class="icos-sd2"></span>
                    <span class="icos-sd"></span>
                    <span class="icos-hd3"></span>
                    <span class="icos-hd2"></span>
                    <span class="icos-hd"></span>
                    <span class="icos-settings2"></span>
                    <span class="icos-settings"></span>
                    <span class="icos-cog4"></span>
                    <span class="icos-cog3"></span>
                    <span class="icos-cog2"></span>
                    <span class="icos-cog"></span>
                    
                    <span class="icos-comment"></span>
                    <span class="icos-female"></span>
                    <span class="icos-admin"></span>
                    <span class="icos-users2"></span>
                    <span class="icos-user2"></span>
                    <span class="icos-male"></span>
                    <span class="icos-admin2"></span>
                    <span class="icos-users"></span>
                    <span class="icos-user"></span>
                    <span class="icos-exit"></span>
                    <span class="icos-running"></span>
                	<span class="icos-walking"></span>
                    <span class="icos-dropbox"></span>
                    <span class="icos-ichat"></span>
                    <span class="icos-myspace"></span>
                    <span class="icos-like"></span>
                    <span class="icos-facebook"></span>
                    <span class="icos-vimeo"></span>
                    <span class="icos-skype"></span>
                    <span class="icos-youtube"></span>
                    <span class="icos-moby"></span>
                    <span class="icos-lastfm"></span>
                    <span class="icos-stumbleupon"></span>
                    <span class="icos-dribbble2"></span>
                    <span class="icos-dribbble"></span>
                    <span class="icos-plixi"></span>
                    <span class="icos-tumbler"></span>
                	<span class="icos-delicious"></span>
                    <span class="icos-buzz"></span>
                    <span class="icos-digg2"></span>
                    <span class="icos-digg"></span>
                    <span class="icos-cart4"></span>
                    <span class="icos-cart3"></span>
                    <span class="icos-cart2"></span>
                    <span class="icos-cart"></span>
                    <span class="icos-basket2"></span>
                    <span class="icos-basket"></span>
                    <span class="icos-stand"></span>
                    <span class="icos-piggybank"></span>
                    <span class="icos-pricetag2"></span>
                    <span class="icos-pricetag"></span>
                    <span class="icos-money2"></span>
                    <span class="icos-money"></span>
                    <span class="icos-money3"></span>
                    
                    <span class="icos-paypal3"></span>
                    <span class="icos-paypal2"></span>
                    <span class="icos-paypal"></span>
                    <span class="icos-bag"></span>
                    <span class="icos-purse"></span>
                    <span class="icos-shoppingbag"></span>
                    <span class="icos-travelcase"></span>
                    <span class="icos-planecase"></span>
                    <span class="icos-suitcase"></span>
                    <span class="icos-medicase"></span>
                    <span class="icos-trolly"></span>
                	<span class="icos-socks"></span>
                    <span class="icos-pants"></span>
                    <span class="icos-shirt"></span>
                    <span class="icos-mcalendar"></span>
                    <span class="icos-dcalendar"></span>
                    <span class="icos-clock"></span>
                    <span class="icos-timer"></span>
                    <span class="icos-stoptimer"></span>
                    <span class="icos-alarm"></span>
                    <span class="icos-bandaid"></span>
                    <span class="icos-info"></span>
                    <span class="icos-car"></span>
                    <span class="icos-truck"></span>
                    <span class="icos-airplane"></span>
                    <span class="icos-cat"></span>
                    <span class="icos-baloons"></span>
                	<span class="icos-create"></span>
                    <span class="icos-windows"></span>
                    <span class="icos-linux"></span>
                    <span class="icos-macos"></span>
                    <span class="icos-tags"></span>
                    <span class="icos-tag"></span>
                    <span class="icos-unlocked"></span>
                    <span class="icos-locked"></span>
                    <span class="icos-folder"></span>
                    <span class="icos-bullseye"></span>
                    <span class="icos-loading"></span>
                    <span class="icos-safari"></span>
                    <span class="icos-chrome"></span>
                    <span class="icos-ff"></span>
                    <span class="icos-footprints"></span>
                    <span class="icos-paperclip"></span>
                    <span class="icos-preview"></span>
                    
                    <span class="icos-cloud-download"></span>
                    <span class="icos-cloud-upload"></span>
                    <span class="icos-cloud"></span>
                    <span class="icos-beta"></span>
                    <span class="icos-globe"></span>
                    <span class="icos-robot"></span>
                    <span class="icos-bell2"></span>
                    <span class="icos-bell"></span>
                    <span class="icos-alert"></span>
                    <span class="icos-postcard"></span>
                    <span class="icos-files"></span>
                	<span class="icos-archive"></span>
                    <span class="icos-vault"></span>
                    <span class="icos-pacman"></span>
                    <span class="icos-companies"></span>
                    <span class="icos-rss"></span>
                    <span class="icos-help"></span>
                    <span class="icos-email"></span>
                    <span class="icos-umbrella"></span>
                    <span class="icos-uc"></span>
                    <span class="icos-tree"></span>
                    <span class="icos-books"></span>
                    <span class="icos-books2"></span>
                    <span class="icos-notebook"></span>
                    <span class="icos-link2"></span>
                    <span class="icos-link"></span>
                    <span class="icos-home2"></span>
                	<span class="icos-home"></span>
                    <span class="icos-cup"></span>
                    <span class="icos-finish"></span>
                    <span class="icos-flag2"></span>
                    <span class="icos-flag"></span>
                    <span class="icos-upload"></span>
                    <span class="icos-download2"></span>
                    <span class="icos-trash"></span>
                    <span class="icos-downloadto"></span>
                    <span class="icos-search"></span>
                    <span class="icos-dates"></span>
                    <span class="icos-vbar"></span>
                    <span class="icos-copypaste"></span>
                    <span class="icos-list3"></span>
                    <span class="icos-create2"></span>
                    <span class="icos-fullscreen2"></span>
                    <span class="icos-cart5"></span>
                </div>
            </div>
        </div>
        <!-- End Icons -->

        <!-- Chart -->
        <div class="widget chartWrapper">
            <div class="whead"><h6>Charts</h6><div class="clear"></div></div>
            <div class="body"><div class="chart"></div></div>
        </div>
    
        <div class="fluid">
        
            <!-- Bars chart -->
            <div class="widget grid6 chartWrapper">
                <div class="whead"><h6>Vertican bars</h6><div class="clear"></div></div>
                <div class="body"><div class="bars" id="placeholder1"></div></div>
            </div>
            
            <!-- Bars chart -->
            <div class="widget grid6 chartWrapper">
                <div class="whead"><h6>Horizontal bars</h6><div class="clear"></div></div>
                <div class="body"><div class="bars" id="placeholder1_h"></div></div>
            </div>
        
        </div>
    
        <div class="fluid">
        
            <!-- Donut -->
            <div class="widget grid4 chartWrapper">
                <div class="whead"><h6>Donut chart</h6><div class="clear"></div></div>
                <div class="body"><div class="pie" id="donut"></div></div>
            </div>
            
            <!-- Auto updating chart -->
            <div class="widget grid8 chartWrapper">
                <div class="whead"><h6>Auto updating chart</h6><div class="clear"></div></div>
                <div class="body"><div class="updating"></div></div>
            </div>
            <div class="clear"></div>
            
        </div>
        <!-- End Chart -->

    </div>
    <!-- Main content ends -->