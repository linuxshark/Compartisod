@ModelType Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel

<div class="widget fluid">
    <div class="whead">
        <h6>
            Datos de Contacto</h6>
        <div class="clear">
        </div>
    </div>
    <div class="formRow fluid">
        <div class="grid6">
            <div class="grid3">
                <label class="form-label">
                    Celular 1:</label>
            </div>
            <div class="grid6">
                @Html.TextBoxFor(Function(x) x.Empleado.Celular1,
                New With {
                    .id = "Celular1",
                    .maxLength = "12",
                    .class = "textinput",
                    .onkeypress = "return val_TelefonoFax(event)"
                })
                @Html.ValidationMessageFor(Function(x) x.Empleado.Celular1, "", New With {.class = "reqizq"})
            </div>
        </div>
        <div class="grid6">
            <div class="grid3">
                <label class="form-label">
                    Celular 2:</label>
            </div>
            <div class="grid6">
                @Html.TextBoxFor(Function(x) x.Empleado.Celular2,
                New With {
                    .id = "Celular2",
                    .maxLength = "12",
                    .class = "textinput",
                    .onkeypress = "return val_TelefonoFax(event)"
                })
                @Html.ValidationMessageFor(Function(x) x.Empleado.Celular2, "", New With {.class = "reqizq"})
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="formRow fluid">
        <div class="grid6">
            <div class="grid3">
                <label class="form-label">
                    Teléfono:</label>
            </div>
            <div class="grid6">
                @Html.TextBoxFor(Function(x) x.Empleado.Telefono,
                New With {
                    .id = "Telefono",
                    .maxLength = "12",
                    .class = "textinput",
                    .onkeypress = "return val_TelefonoFax(event)"
                })
                @Html.ValidationMessageFor(Function(x) x.Empleado.Telefono, "", New With {.class = "reqizq"})
            </div>
        </div>
        <div class="grid6">
            <div class="grid3">
                <label class="form-label">
                    Email:</label>
            </div>
            <div class="grid6">
                @Html.TextBoxFor(Function(x) x.Empleado.Email,
                New With {
                    .id = "Email",
                    .maxLength = "50",
                    .class = "textinput"
                })
                @Html.ValidationMessageFor(Function(x) x.Empleado.Email, "", New With {.class = "reqizq"})
            </div>
        </div>
    </div>
    <div class="formRow fluid">
        <div class="grid6">
            <div class="grid3">
                <label class="form-label">
                    Dirección:</label>
            </div>
            <div class="grid6">
                @Html.TextBoxFor(Function(x) x.Empleado.Direccion,
                New With {
                    .id = "Direccion",
                    .maxLength = "200",
                    .class = "textinput"
                })
                @Html.ValidationMessageFor(Function(x) x.Empleado.Direccion, "", New With {.class = "reqizq"})
            </div>
        </div>
    </div>
</div>
