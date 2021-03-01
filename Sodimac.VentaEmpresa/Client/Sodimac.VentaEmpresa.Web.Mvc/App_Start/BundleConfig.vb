Imports System.Web.Optimization

Public Class BundleConfig
    ' For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
    Public Shared Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/jqjs").Include(
                   "~/Content/js/jquery.js"))

        bundles.Add(New ScriptBundle("~/bundles/spinnjs").Include(
                   "~/Content/js/plugins/forms/ui.spinner.js"))

        bundles.Add(New ScriptBundle("~/bundles/msljs").Include(
                   "~/Content/js/plugins/forms/jquery.mousewheel.js"))


        bundles.Add(New ScriptBundle("~/bundles/jquijs").Include(
       "~/Content/js/jquery-ui.js"))


      
        bundles.Add(New ScriptBundle("~/Scripts/jqval").Include(
                    "~/Scripts/jquery.unobtrusive*",
                    "~/Scripts/jquery.validate*"))


        'NUEVOS AGREGADOS
        bundles.Add(New ScriptBundle("~/bundles/jqall/js").Include(
                    "~/Content/js/plugins/charts/excanvas.js",
                    "~/Content/js/plugins/charts/jquery.flot.js",
                    "~/Content/js/plugins/charts/jquery.flot.orderBars.js",
                    "~/Content/js/plugins/charts/jquery.flot.pie.js",
                    "~/Content/js/plugins/charts/jquery.flot.resize.js",
                    "~/Content/js/plugins/charts/jquery.sparkline.js",
                    "~/Content/js/plugins/tables/jquery.dataTables.js",
                    "~/Content/js/plugins/tables/jquery.sortable.js",
                    "~/Content/js/plugins/tables/jquery.resizable.js",
                    "~/Content/js/plugins/forms/autogrowtextarea.js",
                    "~/Content/js/plugins/forms/jquery.uniform.js",
                    "~/Content/js/plugins/forms/jquery.inputlimiter.js",
                    "~/Content/js/plugins/forms/jquery.tagsinput.js",
                    "~/Content/js/plugins/forms/jquery.maskedinput.js",
                    "~/Content/js/plugins/forms/jquery.autotab.js",
                    "~/Content/js/plugins/forms/jquery.chosen.js",
                    "~/Content/js/plugins/forms/jquery.dualListBox.js",
                    "~/Content/js/plugins/forms/jquery.cleditor.js",
                    "~/Content/js/plugins/forms/jquery.ibutton.js",
                    "~/Content/js/plugins/forms/jquery.validationEngine-en.js",
                    "~/Content/js/plugins/forms/jquery.validationEngine.js",
                    "~/Content/js/plugins/uploader/plupload.js",
                    "~/Content/js/plugins/uploader/plupload.html4.js",
                    "~/Content/js/plugins/uploader/plupload.html5.js",
                    "~/Content/js/plugins/uploader/jquery.plupload.queue.js",
                    "~/Content/js/plugins/wizards/jquery.form.wizard.js",
                    "~/Content/js/plugins/wizards/jquery.validate.js",
                    "~/Content/js/plugins/wizards/jquery.form.js",
                    "~/Content/js/plugins/ui/jquery.collapsible.js",
                    "~/Content/js/plugins/ui/jquery.breadcrumbs.js",
                    "~/Content/js/plugins/ui/jquery.tipsy.js",
                    "~/Content/js/plugins/ui/jquery.progress.js",
                    "~/Content/js/plugins/ui/jquery.timeentry.js",
                    "~/Content/js/plugins/ui/jquery.colorpicker.js",
                    "~/Content/js/plugins/ui/jquery.jgrowl.js",
                    "~/Content/js/plugins/ui/jquery.fancybox.js",
                    "~/Content/js/plugins/ui/jquery.fileTree.js",
                    "~/Content/js/plugins/ui/jquery.sourcerer.js",
                    "~/Content/js/plugins/others/jquery.fullcalendar.js",
                    "~/Content/js/plugins/others/jquery.elfinder.js",
                    "~/Content/js/plugins/ui/jquery.easytabs.js",
                    "~/Content/js/files/bootstrap.js",
                    "~/Content/js/files/functions.js",
                    "~/Content/js/UserControl.Helper.js",
                    "~/Scripts/jquery.autocomplete.js"
                    ))

        bundles.Add(New StyleBundle("~/bundle/jquery-ui/bundle").Include("~/Content/themes/base/*.css", New CssRewriteUrlTransformWrapper()))

        bundles.Add(New StyleBundle("~/bundle/Msctcss").Include(
                    "~/Content/Multiselect/css/jquery.multiselect.css",
                    "~/Content/Multiselect/css/jquery.multiselect.filter.css"
                    ))


        bundles.Add(New ScriptBundle("~/bundles/Msctcjs").Include(
                    "~/Content/Multiselect/js/jquery.multiselect.js",
                    "~/Content/Multiselect/js/jquery.multiselect.filter.js"
                    ))

        bundles.Add(New StyleBundle("~/bundle/jquicss").Include(
                   "~/Content/Multiselect/css/jquery-ui.css"
                   ))

        bundles.Add(New StyleBundle("~/bundle/3devcss").Include(
                   "~/Content/3dev/3dev.css"
                   ))

        bundles.Add(New ScriptBundle("~/bundles/chosjs").Include(
                    "~/Content/chosen/chosen.jquery.min.js",
                    "~/Content/chosen/chosen.jquery.js",
                    "~/Content/chosen/chosen.proto.js",
                    "~/Content/chosen/chosen.proto.min.js"))

        bundles.Add(New StyleBundle("~/bundle/choscss").Include(
                  "~/Content/chosen/chosen.min.css",
                  "~/Content/chosen/chosen.css"
                  ))


        'LOGIN
        bundles.Add(New ScriptBundle("~/bundles/lognjq").Include(
                   "~/Content/login/js/jquery-1.7.2.js"))

        bundles.Add(New ScriptBundle("~/bundles/formjs").Include(
                    "~/Content/js/form2js.js"))

        bundles.Add(New ScriptBundle("~/bundles/jsonjs").Include(
                    "~/Content/js/json.js"
        ))

        bundles.Add(New ScriptBundle("~/bundles/lognjs").Include(
                    "~/Content/login/js/bootstrap.js",
                    "~/Content/login/js/jquery-jrumble.js",
                    "~/Content/login/js/login.js",
                    "~/Content/login/js/global.js",
                    "~/Content/login/js/iphone.check.js"))


    End Sub
End Class