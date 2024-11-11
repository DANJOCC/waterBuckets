# waterBuckets

## Guia - Español

### Requerimientos
IDE: Visual Studio 2022
Framework: .NET 8
### Instalación
1. Abrir Visual Studio.
2. Seleccionar la opcion de clonar repositorio.
3. Configurar las rutas para el proyecto
4. Verificar que el repositorio local se creo.
5. Abrir de nuevo visual studio 2022.
6. Seleccionar opcion de abrir proyecto.
7. Seleccionar proyecto clonado.

### Descripcion
La tarea es crear una API que calcule los pasos necesarios para obtener una medida exacta de galones de agua, utilizando dos cubetas de capacidades X y Y.
El backend debe de procesar este problema eficientemente y devolver la solución en formato JSON mediante una RESTful API.

#### Condiciones

1. Solo se pueden realizar acciones de llenar, vaciar y transferir todo el contenido de una cubeta a otra.
2. Los valores de las capacidades de las cubetas y los gallones solicitados son numeros enteros positivos.
3. El body de la peticion POST para obtener la solución según los valores establecidos tiene la forma de:
   ```
   {
     “x_capacity”:2,
      “y_capacity":10,
      “z_amount_wanted”:4,   
   }
   ```
4. La solucion tiene que ser dada de la siguiente forma:
  ```
  {
"solution": [
{"step": 1, "bucketX": 2, "bucketY": 0, "action": "Fill bucket X"},
{"step": 2, "bucketX": 0, "bucketY": 2, "action": "Transfer from bucket X to Y"},
{"step": 3, "bucketX": 2, "bucketY": 2, "action": "Fill bucket X"},
{"step": 4, "bucketX": 0, "bucketY": 4, "action": "Transfer from bucket X to Y", "status": "Solved"}
]
}
  ```

5. En caso de no encontrar solucion devolver un mensaje indicando que no existe solucion

 
