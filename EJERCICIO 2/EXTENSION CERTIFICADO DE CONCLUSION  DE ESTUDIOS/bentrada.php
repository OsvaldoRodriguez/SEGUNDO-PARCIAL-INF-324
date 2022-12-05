<?php
  include "conexion.inc.php";
  if(!isset($_SESSION)){ // si no ha iniciado sesion 
      session_start(); 
  } 
  $usuario = $_SESSION["usuario"];
  $sql="select * from flujotramite ";
  $sql.="where usuario='".$usuario."' and fechafin is null ";
  $resultado=mysqli_query($con, $sql);
?>

<!DOCTYPE html>
<html>
  <head>

    <title>Procesos Pendientes</title>
    <link rel="stylesheet" href="assets/vendor/fonts/boxicons.css" />
    <link rel="stylesheet" href="assets/vendor/css/core.css" class="template-customizer-core-css" />
    <link rel="stylesheet" href="assets/vendor/css/theme-default.css" class="template-customizer-theme-css" />
    <link rel="stylesheet" href="assets/css/demo.css" />
    <link rel="stylesheet" href="/assets/vendor/libs/perfect-scrollbar/perfect-scrollbar.css" />

  </head>

  <body>
    <div class="layout-wrapper layout-content-navbar">
      <div class="layout-container">
        <div class="layout-page">
          <div class="content-wrapper">
            <div class="container-xxl flex-grow-1 container-p-y">
              <h4 class="fw-bold py-3 mb-4" align='center'>TAREAS PENDIENTES DE: <?php echo "<br/><br/>".$usuario; ?>  </h4>
              <div class="card">
                <h5 class="card-header"></h5>
                <div class="table-responsive text-nowrap">
                  <table class="table table-hover">
                    <thead>
                      <tr class="negrita1">
                        <th>Flujo</th>
                        <th>Proceso</th>
                        <th>Nro. Tramite</th>
                        <th>Fecha de inicio</th>
                        <th>Fecha final</th>
                        <?php 
                          if($_SESSION['rol'] == 'Kardex'){
                        ?>
                            <!-- echo "<td>".$fila["usuario_tarea"]."</td>"; -->
                            <th> USUARIO </th>
                        <?php 
                          }
                        ?>
                        <th>Estado</th>
                      </tr>
                    </thead>
                    <tbody class="table-border-bottom-0">
                      <?php 
                        while ($fila = mysqli_fetch_array($resultado))
                        {
                          echo "<tr>";
                          echo "<th>".$fila["Flujo"]."</th>";
                          echo "<th>".$fila["proceso"]."</th>";
                          echo "<th>".$fila["nro_tramite"]."</th>";
                          echo "<th>".$fila["fechaini"]."</th>";
                          if(isset($fila["fechafin"])){
                            echo "<th> Terminado </th>";
                          }else{
                            echo "<th> No Terminado </th>";
                          }
                          if($_SESSION['rol'] == 'Kardex'){
                            echo "<th>".$fila["usuario_tarea"]."</th>";
                          }
                          echo "<th><a href='flujo.php?flujo=".$fila["Flujo"]."&proceso=".$fila["proceso"]."&nro_tramite=".$fila['nro_tramite']."'> Editar </td>";
                          echo "</tr>";
                        }
                      ?>
                    </tbody>
                
                  </table>
                  <form action="index.php">
                    <button class="btn btn-primary d-grid w-100" type="submit" value="Volver" name = "Volver">Volver</button>
                  </form>
                </div>
              </div>
              
            </div>
            
          </div>
        </div>
      </div>
    </div>    
    <footer class="content-footer footer bg-footer-theme">
              <div class="container-xxl d-flex flex-wrap justify-content-between py-2 flex-md-row flex-column">
                <div class="mb-2 mb-md-0"> Segundo Parcial INF-324 </div>
                <div> 2022 </div>
              </div>
            </footer>
  </body>
</html>

