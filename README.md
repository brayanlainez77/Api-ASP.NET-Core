# Api-ASP.NET-Core

## Crear el proyecto desde la terminal
 * Crear una carpeta con el nombre Api-ASP.NET-Core
 * Cree el proyecto: ```dotnet new Api-ASP.NET-Core```
 * Añada el paquete de Mysql: ```dotnet add package MySqlConnector```
 * Correr el proyecto: ```dotnet run```

## Verifica el funcionamiento con el Endpoints por defecto
 * Acedemos a: https://localhost:5001/weatherforecast

## New API Endpoints of products for CRUD operations
 * POST https://localhost:5001/api/producto  
 ```{"nombre": "Chocolate 1", "codigo_barra": "C1", "precio": 100, "disponible": 1, "detalle": "detalle", "imagen": "img"}```

 * POST https://localhost:5001/api/producto  
 ```{"nombre": "Chocolate 2", "codigo_barra": "C2", "precio": 200, "disponible": 1, "detalle": "detalle", "imagen": "img"}```

 * POST https://localhost:5001/api/producto  
 ```{"nombre": "Chocolate 3", "codigo_barra": "C3", "precio": 300, "disponible": 1, "detalle": "detalle", "imagen": "img"}```

 * GET https://localhost:5001/api/producto  
 Output:  
   ```[{"nombre": "Chocolate 1", "codigo_barra": "C1", "precio": 100, "disponible": 1, "detalle": "detalle", "imagen": "img"},{"nombre": "Chocolate 2", "codigo_barra": "C2", "precio": 200, "disponible": 1, "detalle": "detalle", "imagen": "img"},{"nombre": "Chocolate 3", "codigo_barra": "C3", "precio": 300, "disponible": 1, "detalle": "detalle", "imagen": "img"}]```
 * DELETE https://localhost:5001/api/producto/3    
 El producto con id 3 se elimino

 * PUT https://localhost:5001/api/producto/1  
 ```{"nombre": "Chocolate 1", "codigo_barra": "C1", "precio": 150, "disponible": 1, "detalle": "detalle", "imagen": "img"}```

 * GET https://localhost:5001/api/producto  
 Output:  
 ```[{"nombre": "Chocolate 1", "codigo_barra": "C1", "precio": 150, "disponible": 1, "detalle": "detalle", "imagen": "img"},{"nombre": "Chocolate 2", "codigo_barra": "C2", "precio": 200, "disponible": 1, "detalle": "detalle", "imagen": "img"},{"nombre": "Chocolate 3", "codigo_barra": "C3", "precio": 300, "disponible": 1, "detalle": "detalle", "imagen": "img"}]```
  * GET https://localhost:5001/api/producto/1

 * DELETE https://localhost:5001/api/producto  
 Se eliminaron todos los productos

  * GET https://localhost:5001/api/producto  
  Output:  
  ```[]```

  *Referencias: https://mysqlconnector.net/tutorials/net-core-mvc/*