# 🔥 Floor is Lava: Chaos Edition

> **Videojuego 3D de plataformas, físicas y supervivencia cómica.**  
> Controlas a un muñeco de juguete que debe trepar muebles gigantescos en una habitación antes de que la lava ardiente lo consuma todo.

---

## 👥 Equipo de Desarrollo y Roles
* **Programación de Gameplay:** Movimiento 3D del personaje, saltos y físicas.
* **Programación de Entorno:** Sistema de subida progresiva de lava, colisiones y eventos "Modo Caos".
* **Diseño de Niveles y Arte 3D:** Modelado low-poly de muebles, habitación y personaje Chipi.
* **UI y Audio:** Interfaz de usuario (vidas, cronómetro) y efectos sonoros.

---

## 🚀 Primera Entrega (Sprint 1 - Prototipo Base)
Este repositorio contiene el prototipo base funcional:
* ✅ **Controlador 3D del Jugador (`PlayerController.cs`):** Movimiento con WASD, salto elástico y gravedad.
* ✅ **Sistema de Peligro de Lava (`LavaHazard.cs`):** Plano de lava que sube de altura y reinicia al jugador al checkpoint si cae.
* ✅ **Plataformas de Físicas Temporales (`FloatingObject.cs`):** Cojines que flotan en la lava unos segundos antes de quemarse.
* ✅ **Gestor de Nivel (`GameManager.cs`):** Control de vidas, cronómetro y victoria al alcanzar la meta.
* ✅ **Demo 3D Jugable Inmediata (`play_demo.html`):** Prototipo jugable 3D directamente ejecutable en cualquier navegador sin instalar nada.

---

## 🕹️ Controles
* **W, A, S, D:** Mover al personaje
* **Espacio:** Saltar
* **Shift Izquierdo:** Correr (Sprint)
* **Mouse:** Rotar la cámara

---

## 🌳 Estructura de Ramas (Git Flow)
* `main`: Rama de producción / entregas estables.
* `develop`: Rama de integración activa del equipo.
* `feature/player-controller`: Desarrollo del controlador de físicas y salto.
* `feature/lava-system`: Lógica de subida de lava y colisiones.
* `feature/game-manager-and-demo`: Condiciones de victoria y demo interactiva.
