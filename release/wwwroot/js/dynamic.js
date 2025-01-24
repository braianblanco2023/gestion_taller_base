        window.onload = function () {
            muestra_DatosAutomotor();
        };
        //funciones para ocultar o mostrar formularios
        function muestra_DatosAutomotor(){        
            //var contenedor1 = document.getElementById("div_DatosAutomotor");
            //var contenedor2 = document.getElementById("div_NuevaAtencion");
            var contenedor4 = document.getElementById("div_DatosAtencion");
            var contenedor5 = document.getElementById("div_Guardar");
            var contenedor6 = document.getElementById("div_Historial");
            //contenedor1.style.display = "block";
            //contenedor2.style.display = "block";
            contenedor4.style.display = "none";
            contenedor5.style.display = "none";
            contenedor6.style.display = "none";
            //si existe... se muestra el form Historial
            //var contenedor5 = document.getElementById("div_Historial");
            //contenedor5.style.display = "block";     
			setTimeout(function(){
			    var txt1 = document.getElementById("txt1_1");
            	txt1.focus();
			}, 250);
            return true;
        }
        /*
         function OnSuccess(response) {
             alert(response.d);
         }
        */
        function muestra_DatosAtencion(){
        	var contenedor1 = document.getElementById("div_DatosAtencion");
            var contenedor2 = document.getElementById("div_Guardar");
            
            contenedor1.style.display = "block";
            contenedor2.style.display = "block";
            
		    
            setTimeout(function(){
			    var txt2 = document.getElementById("txt2_1");
            	txt2.focus();
			}, 350);
            return true;
        }
        function mostrar_Historial() {
            var contenedor3 = document.getElementById("div_Historial");
            contenedor3.style.display = "block";
        }
        //funcion que refresca el Form tras salvar los datos
        function limpiar_Form(){
        	location.reload();
        }
        //funciones de redireccion para los botones menú
        function irAMenu() {
            var nombrePagina1 = 'Menu';
            window.location.href = nombrePagina1;
        }
        function irABuscar() {
            var nombrePagina2 = 'RegistroForm';
            window.location.href = nombrePagina2;
        }
        function irADashboard() {
            var nombrePAgina3 = 'DashboardForm';
            window.location.href = nombrePAgina3;
        }
        //Bloquear o desbloquear boton de Historial según exista o no historial para el vehículo 
        var textbox = document.getElementById('txtMarca');
        var boton = document.getElementById('btnHistorial');

        var txtPatenteB = document.getElementById('txt_patente');
        var btnBuscaPatente = document.getElementById('btn_buscar');

        //btnBuscaPatente.disabled = true; // Bloquear el botón
        //btnBuscaPatente.classList.add('bloqueado');

        document.addEventListener('DOMContentLoaded', function () {
            if (textbox.value.trim() !== '') {
                boton.disabled = false; // Desbloquear el botón
            } else {
                boton.disabled = true; // Bloquear el botón
                boton.classList.add('bloqueado'); //agregamos una clase HTML al botón para darle color con CSS
            }
        });
        //Bloquear o desbloquear boton de Busqueda de Patente segun se escriba o no algo en el textbox
        txtPatenteB.addEventListener('input', function () {
            if (txtPatenteB.value.trim() !== '') {
                btnBuscaPatente.disabled = false; // Desbloquear el botón
                btnBuscaPatente.classList.remove('bloqueado');
            } else {
                btnBuscaPatente.disabled = true; // Bloquear el botón
                btnBuscaPatente.classList.add('bloqueado');
            }
        });
        //funciones para redimensionar los Textarea
		const tx = document.getElementsByTagName("textarea");
		for (let i = 0; i < tx.length; i++) {
		  tx[i].setAttribute("style", "height: 34px;");
		  tx[i].addEventListener("input", OnInput, false);
		}
		function OnInput() {		  
		  this.style.height = (this.scrollHeight) + "px";
		}
		//funciones para colorear los div que enmascaran a los textarea, al recibir focus los últimos
		const tx_area1 = document.getElementById("txt2_1");
		const tx_area2 = document.getElementById("txt2_2");
		tx_area1.addEventListener("focus",OnFocus1, false);
		tx_area1.addEventListener("blur", OnBlur1, false);
		tx_area2.addEventListener("focus",OnFocus2, false);
		tx_area2.addEventListener("blur", OnBlur2, false);
		var mask1 = document.getElementById("area_mask1");
		var mask2 = document.getElementById("area_mask2");
	    function OnFocus1(){
	    	mask1.setAttribute("style", "border-color: #0f7ef1;");
	    }
		function OnBlur1(){
			mask1.setAttribute("style", "border-color: #ddd;");	
		}
		function OnFocus2(){
	    	mask2.setAttribute("style", "border-color: #0f7ef1;");
	    }
		function OnBlur2(){
			mask2.setAttribute("style", "border-color: #ddd;");	
		}
        function calcular() {
            costo3.value = parseFloat(costo1.value) + parseFloat(costo2.value);
        };