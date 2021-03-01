@ModelType  Sodimac.VentaEmpresa.Web.Mvc.ComisionViewModel
@Imports Sodimac.VentaEmpresa.Common
@If (Not Model.PlanVenta.ListaComisionEscalaTiempoServicio Is Nothing) Then

    If (Not Model.PlanVenta.ListaComisionEscalaTiempoServicio.Count = 0) Then
  
        Dim gridEscalaComision = New WebGrid(ajaxUpdateContainerId:="contenedorgrilla-ListadoEscalaComision")
        gridEscalaComision.Bind(Model.PlanVenta.ListaComisionEscalaTiempoServicio)
        @gridEscalaComision.GetHtml(
        headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
        htmlAttributes:=New With {.id = "dgvDatos", .class = "tDefault"},
        mode:=WebGridPagerModes.All,
        columns:=gridEscalaComision.Columns(
            gridEscalaComision.Column("IdComisionTiempoServicio", "Código", canSort:=True, style:="person hide"),
            gridEscalaComision.Column("ComisionPeriodo.NombrePeriodo", "Periodo", canSort:=True, style:="person"),
            gridEscalaComision.Column("Cargo.NombreCargo", "Cargo", canSort:=True, style:="person"),
            gridEscalaComision.Column("TiempoServicio", "Tiempo Servicio", canSort:=True, style:="person"),
            gridEscalaComision.Column("PlanVenta", "Plan Venta", canSort:=True, style:="person"),
            gridEscalaComision.Column("IngresoBasico", "Ingreso Básico", canSort:=True, style:="person"),
            gridEscalaComision.Column("FechaActualizacion", "Actualizado", canSort:=True, Style:="personCentrado", Format:=
            Function(item)
                If item.FechaActualizacion = New DateTime(1, 1, 1) Then
                    Return "-"
                Else
                    Return Format(item.FechaActualizacion, "dd/MM/yyyy")
                End If
            End Function),
            gridEscalaComision.Column("", "Acciones", canSort:=False, Format:=
           Function(item)
               Return Html.ActionLink(" ", "GestionarEscalaComision", "Comision",
                New With {
                    .IdComisionEscala = item.IdComisionTiempoServicio
                },
                New With {
                    .class = "select_table",
                    .title = "Ver Detalle"
                })
           End Function
      )
     )
 )
    End If
    
Else
@<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
End If