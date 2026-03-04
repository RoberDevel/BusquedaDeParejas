# BusquedaDeParejas

Juego de memoria de escritorio hecho con Windows Forms.  
El objetivo es encontrar todas las parejas de cartas antes de que se termine el tiempo.

**Proyecto realizado como trabajo en la FP de Desarrollo de Aplicaciones Multiplataforma**

## Descripcion del proyecto

`BusquedaDeParejas` es una aplicacion WinForms en C# donde el jugador destapa cartas (imagenes de coches) y debe emparejarlas.

El flujo principal es:

1. Menu inicial.
2. Seleccion de dificultad (tiempo disponible).
3. Partida con 12 cartas (6 parejas).
4. Pantalla de victoria o derrota.
5. Ranking local en memoria con nick y tiempo.

Incluye soporte de idioma en:

- Espanol (`es-ES`)
- Ingles (`en-US`)
- Frances (`fr-FR`)

## Tecnologias que usa

- Lenguaje: `C#`
- Plataforma: `.NET Framework 4.7.2`
- Interfaz grafica: `Windows Forms`
- IDE recomendado: `Visual Studio 2019/2022/2026`
- Gestion de proyecto: `MSBuild` + solucion `.sln`
- Recursos: `.resx` (textos multiidioma e imagenes)

## Requisitos para ejecutarlo

Este proyecto esta pensado para **Windows**.

Necesitas tener instalado:

1. **Visual Studio** (2019, 2022 o 2026).
2. Workload: **.NET desktop development**.
3. **.NET Framework 4.7.2 Targeting Pack / Developer Pack**.

Notas:

- No usa `package.json`, `npm`, `pip` ni dependencias externas obligatorias de NuGet en el proyecto actual.
- Si tu Visual Studio no muestra 4.7.2, instala el Developer Pack de .NET Framework 4.7.2 y vuelve a abrir la solucion.

## Como ejecutarlo (Visual Studio)

1. Abre Visual Studio.
2. Ve a `File > Open > Project/Solution`.
3. Selecciona `BusquedaDeParejas.sln`.
4. En la barra superior usa la configuracion `Debug | Any CPU`.
5. Ejecuta con `F5` (o boton Start).

Punto de entrada:

- `Program.cs` lanza `MenuInicio` con `Application.Run(new MenuInicio());`.

## Como compilar desde linea de comandos (opcional)

Desde la carpeta raiz del repositorio:

```powershell
msbuild .\BusquedaDeParejas.sln /p:Configuration=Debug
```

El ejecutable se genera en:

- `.\BusquedaDeParejas\bin\Debug\BusquedaDeParejas.exe`

## Mecanica del juego

- El tablero usa `12` `PictureBox` (6 parejas).
- Ganas cuando encuentras las `6` parejas.
- Si el temporizador llega a `0`, pierdes.
- El tiempo depende de la dificultad elegida:
  - Facil: `120` segundos
  - Media: `60` segundos
  - Dificil: `30` segundos
  - Extrema: `15` segundos

## Ranking

- Al ganar, se pide un nick.
- Se guarda `{Nick, Tiempo}` en una lista en memoria (`BindingList<Jugador>`).
- El ranking se ordena por tiempo (menor es mejor).
- El ranking no se persiste en disco actualmente; se reinicia al cerrar la app.

## Estructura del proyecto

- `BusquedaDeParejas.sln`: solucion principal.
- `BusquedaDeParejas/BusquedaDeParejas.csproj`: proyecto WinForms (.NET Framework 4.7.2).
- `BusquedaDeParejas/Program.cs`: punto de entrada.
- `BusquedaDeParejas/MenuInicio.cs`: menu inicial, dificultad e idioma.
- `BusquedaDeParejas/FormJuego.cs`: logica principal de cartas y temporizador.
- `BusquedaDeParejas/Ganador.cs`: pantalla de victoria y alta en ranking.
- `BusquedaDeParejas/perder.cs`: pantalla de derrota.
- `BusquedaDeParejas/Ranking.cs`: visualizacion de clasificacion.
- `BusquedaDeParejas/Idiomas/`: recursos de localizacion (`.resx`).
- `BusquedaDeParejas/Resources/`: imagenes y gifs del juego.

## Posibles mejoras

- Persistir ranking en archivo (`json`, `xml` o base de datos local).
- Reducir codigo duplicado en `FormJuego.cs` (handlers de cartas).
- Anadir tests de logica desacoplada de UI.
- Anadir instalador o publicacion automatica.
