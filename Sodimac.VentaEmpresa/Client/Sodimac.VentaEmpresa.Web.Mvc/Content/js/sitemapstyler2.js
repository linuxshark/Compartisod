/* 

	Sitemap Styler v0.1
	written by Alen Grakalic, provided by Css Globe (cssglobe.com)
	visit http://cssglobe.com/lab/sitemap_styler/
	
*/
//this.sitemapstyler = function () {
function sitemap(IdSitemap,idspan) {
    var sitemap = document.getElementById(IdSitemap)
    if (sitemap) {
        this.listItem = function (li) {
            var span = document.createElement("span");
            span.className = "expanded";
            span.setAttribute("id", idspan);
            if (li.getElementsByTagName("ul").length > 0) {
                
                var ul = li.getElementsByTagName("ul")[0];
                ul.style.display = "block";
                ul.style.opacity = "1.0";

                span.onclick = function () {
                    if (ul.style.display == "none") {
                        $(ul).css("display", "block").stop().animate({ opacity: "1.0" }, 500);
                    } else {
                        $(ul).css("display", "none").stop().animate({ opacity: "0.0" }, 1);
                    }
                    this.className = (ul.style.display == "none") ? "collapsed" : "expanded";
                };
  
            };
            li.appendChild(span);
        };

        var items = sitemap.getElementsByTagName("li");
        
        for (var i = 0; i < items.length; i++) {
            listItem(items[i]);
        };

    };
//}
}
//window.onload = sitemapstyler;

$(window).load(function () {
    sitemap("sitemap", "idspan");
    sitemap("sitemap2", "idspan2");
});