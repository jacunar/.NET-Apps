Agregue el complemento Certificado a Microsoft Management Console siguiendo estos pasos:

Haga clic en Inicio > Ejecutar, escriba mmc,y después presione Entrar.
En el menú Archivo, haga clic en Añadir o quitar complemento.
Seleccione Certificados, haga clic en Añadir, seleccione Cuenta de equipo y, a continuación, haga clic en Siguiente.
Seleccione Equipo local (equipo en el que se ejecuta la consola) y haga clic en Finalizar.
Haga clic en Aceptar.

Solucioné mi problema moviendo una copia del certificado x.509 con el que estaba trabajando desde la carpeta "Certificados/personal/certificados" a la carpeta "Entidades de certificación Raíz de confianza/Certificados" dentro del almacén de certificados.
