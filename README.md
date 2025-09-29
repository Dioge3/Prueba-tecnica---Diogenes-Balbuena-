🎰 Roulette Game

Este proyecto es una aplicación de Ruleta compuesta por:

API .NET Core (backend)

Frontend Vue 3 (interfaz de usuario)

El proyecto está diseñado para ser fácil de configurar y levantar en local. Solo necesitas actualizar tu Connection String para la base de datos en appsettings.Development.json y ejecutar unos comandos simples.

🖥 Requisitos previos

Antes de comenzar, asegúrate de tener instalados los siguientes:

.NET 8 SDK

Node.js
 (v16+ recomendada)

npm
 (se instala junto a Node.js)

Un editor de código, preferiblemente Visual Studio Code
 o Visual Studio 2022+

🔧 Configuración del Backend (.NET Core API)

Abre la carpeta del proyecto RouletteApi en Visual Studio o tu editor favorito.

Abre el archivo appsettings.Development.json y cambia la Connection String a tu base de datos local:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=TuServidor;Database=roulette;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

Esto levantará la API en https://localhost:5001 (o el puerto que tengas configurado).

🌐 Configuración del Frontend (Vue 3)

Abre la carpeta del frontend roulette-vue en tu editor.

Instala las dependencias:

npm install


Ejecuta la aplicación en modo desarrollo:

npm run serve


Esto levantará el frontend en http://localhost:5173 (o el puerto que indique la terminal).

Asegúrate de que la API esté corriendo para que el frontend pueda consumir los endpoints.

📝 Uso

Al iniciar, ingresa el nombre del jugador.

Realiza apuestas por color, número o par/impar.

La API calculará automáticamente las ganancias y actualizará el monto del jugador.

Guarda los resultados directamente desde la interfaz.
