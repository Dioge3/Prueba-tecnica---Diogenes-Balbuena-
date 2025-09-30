<template>
  <div class="container d-flex flex-column justify-content-center align-items-center vh-100">
    

    <!-- Texto de bienvenida -->
    <div class="text-center mb-4">
      <div class="text-primary mb-1">Welcome to</div>
      <h1 class="fw-bold text-primary">Roulette Game</h1>
    </div>

    <!-- Card con input y botón -->
    <div class="card w-75 p-4 shadow-sm border-0">
      <div class="d-flex flex-column align-items-center gap-3">
        <!-- Input de nombre -->
        <input
          type="text"
          class="form-control form-control-lg"
          v-model="playerName"
          placeholder="Enter your name"
        />

        <!-- Botón para iniciar -->
        <button
          class="btn btn-success btn-lg d-flex align-items-center gap-2"
          @click="startGame"
        >
          Start Game
          <i class="mdi mdi-gamepad-variant"></i>
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter();
const playerName = ref('');

function startGame() {
  if (!playerName.value) return;
  router.push(`/play/${playerName.value}`);
}
</script>

<style scoped>
.card {
  border-radius: 1rem;
  background-color: #f8f9fa; /* Color más moderno */
}
</style>
