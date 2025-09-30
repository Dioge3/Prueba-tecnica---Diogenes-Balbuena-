<template>
  <div class="container py-5">
    <!-- Header -->
    <h2 class="text-center py-4 text-primary">
      Player: <strong>{{ playerName }}</strong>
    </h2>

    <div class="d-flex flex-column align-items-center gap-4">
      <!-- Formulario de apuestas -->
      <div class="card w-75 p-4 shadow-lg border-0 bg-light">
        <div class="mb-3">
          <label class="form-label fw-bold">Amount</label>
          <input type="number" class="form-control form-control-lg" v-model="amount" />
        </div>

        <div class="mb-3">
          <label class="form-label fw-bold">Bet</label>
          <input type="number" class="form-control form-control-lg" v-model="bet" :class="{'is-invalid': betError}" />
          <div class="invalid-feedback">{{ betError }}</div>
        </div>

        <div class="mb-3 d-flex gap-2">
          <select class="form-select" v-model="selectedNumber" :disabled="iEvenOddGuess">
            <option value="" disabled>Select a Number</option>
            <option v-for="num in numbers" :key="num" :value="num">{{ num }}</option>
          </select>

          <select class="form-select" v-model="selectedValue" :disabled="isNumberGuess">
            <option value="" disabled>Select Even or Odd</option>
            <option v-for="opt in numberOptions" :key="opt" :value="opt">{{ opt }}</option>
          </select>
        </div>

        <div class="mb-3">
          <label class="form-label fw-bold">Select Color</label>
          <div class="form-check form-check-inline">
            <input class="form-check-input" type="radio" value="Black" v-model="selectedColor" id="colorBlack">
            <label class="form-check-label text-dark" for="colorBlack">Black</label>
          </div>
          <div class="form-check form-check-inline">
            <input class="form-check-input" type="radio" value="Red" v-model="selectedColor" id="colorRed">
            <label class="form-check-label text-danger" for="colorRed">Red</label>
          </div>
        </div>

        <div class="d-flex justify-content-center gap-3">
          <button class="btn btn-success btn-lg" @click="placeBet" :disabled="!canPlaceBet">
            Place Bet
          </button>
          <button class="btn btn-outline-danger btn-lg" @click="resetGame">
            Reset Game
          </button>
        </div>
      </div>

      <!-- Resultados -->
      <div v-if="showResult" class="w-75">
        <ResultComponent
          :number="selectedNumber"
          :evenOrOdd="selectedValue"
          :color="selectedColor"
          :playerName="playerName"
          :bet="bet"
          :amount="amount"
        />
      </div>

      <!-- Back Button -->
      <button class="btn btn-warning btn-lg mt-3" @click="goHome">
        Back
      </button>
    </div>
  </div>
</template>

<script>
import router from "../router";
import { useRoute } from "vue-router";
import { RouletteService } from '../services/RouletteService.js';
import { ref, onMounted } from 'vue';
import ResultComponent from '../components/ResultComponent.vue';

export default {
  components: { ResultComponent },
  setup() {
    const route = useRoute();
    const playerName = route.params.playerName;
    const amount = ref(0);

    onMounted(async () => {
      const service = new RouletteService();
      const player = await service.getUserAmount(playerName);
      if (player) amount.value = player.amount;
    });

    return { playerName, amount };
  },
  data() {
    return {
      bet: 0,
      betError: "",
      selectedNumber: null,
      selectedValue: null,
      numbers: [],
      numberOptions: ["Even", "Odd"],
      selectedColor: null,
      showResult: false,
    };
  },
  computed: {
    canPlaceBet() {
      return this.bet && this.selectedColor != null;
    },
    isNumberGuess() {
      return this.selectedNumber !== null;
    },
    iEvenOddGuess() {
      return this.selectedValue !== null;
    },
  },
  methods: {
    resetGame() {
      this.bet = 0;
      this.betError = "";
      this.selectedNumber = null;
      this.selectedValue = null;
      this.selectedColor = null;
      this.showResult = false;
      this.updateNumbers();
    },
    updateNumbers() {
      this.numbers = Array.from({ length: 37 }, (_, i) => i);
    },
    placeBet() {
      if (this.canPlaceBet) {
        this.showResult = true;
      }
    },
    goHome() {
      if (confirm("You will lose this match, do you want to exit anyway?")) {
        router.push("/home");
      }
    },
  },
  mounted() {
    this.updateNumbers();
  },
};
</script>

<style scoped>
.card {
  border-radius: 1rem;
}
</style>
