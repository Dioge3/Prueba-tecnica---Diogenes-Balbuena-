<template>
  <div class="card w-100 p-4 shadow-lg bg-light border-0 rounded-3">
    <!-- Header -->
    <div class="text-center mb-4">
      <h2 class="h5 fw-bold text-primary">Results</h2>
    </div>

    <!-- Result Details -->
    <div class="mb-4">
      <p><strong>Roulette Number:</strong> {{ rouletteNumber }}</p>
      <p><strong>Roulette Color:</strong> <span :class="rouletteColorClass">{{ rouletteColor }}</span></p>
      <p v-if="evenOrOdd != null"><strong>Roulette Even or Odd:</strong> {{ rouletteEvenOrOdd }}</p>
      <p v-if="number != null"><strong>Your Number:</strong> {{ number }}</p>
      <p v-if="evenOrOdd != null"><strong>Your Even or Odd Guess:</strong> {{ evenOrOdd }}</p>
      <p><strong>Your Color:</strong> <span :class="colorClass">{{ color }}</span></p>
    </div>

    <!-- Operation Type -->
    <div class="mb-4">
      <p v-if="color && !number && !evenOrOdd"><strong>Operation Type:</strong> Color</p>
      <p v-if="color && number && !evenOrOdd"><strong>Operation Type:</strong> Number And Color</p>
      <p v-if="color && !number && evenOrOdd"><strong>Operation Type:</strong> Even or Odd And Color</p>
    </div>

    <hr />

    <!-- Result and Save Button -->
    <div class="d-flex flex-column flex-md-row justify-content-between align-items-center py-3">
      <div class="mb-3 mb-md-0 text-center text-md-start">
        <p><strong>New Amount Result:</strong> {{ result }}</p>
        <p v-if="isWin" class="text-success fw-bold">Congratulations, you won the bet!</p>
        <p v-else class="text-danger fw-bold">Sorry, you lost the bet!</p>
      </div>
      <button class="btn btn-success" @click="saveBet">
        Save Result <i class="mdi mdi-content-save ms-2"></i>
      </button>
    </div>

    <!-- Footer -->
    <p class="text-center text-muted mt-3">Bet placed by {{ playerName }}</p>
  </div>
</template>

<script>
import { RouletteService } from '../services/RouletteService.js';
import router from '../router/index.js';

export default {
  props: {
    number: { type: Number, required: true },
    evenOrOdd: { type: String, required: true },
    color: { type: String, required: true },
    playerName: { type: String, required: true },
    bet: { type: Number, required: true },
    amount: { type: Number, required: true },
  },
  data() {
    return {
      result: 0,
      isWin: null,
      rouletteColor: '',
      rouletteNumber: '',
      rouletteEvenOrOdd: '',
    };
  },
  mounted() {
    this.makeBet();
  },
  computed: {
    rouletteColorClass() {
      return this.rouletteColor === 'Red' ? 'text-danger fw-bold' : 'text-dark fw-bold';
    },
    colorClass() {
      return this.color === 'Red' ? 'text-danger fw-bold' : 'text-dark fw-bold';
    },
  },
  methods: {
    async makeBet() {
      const service = new RouletteService();
      const roulette = await service.getNumberAndColor();

      this.rouletteNumber = roulette.number;
      this.rouletteColor = roulette.color;
      this.rouletteEvenOrOdd = roulette.number % 2 === 0 ? 'Even' : 'Odd';

      let response;
      if (this.color && !this.number && !this.evenOrOdd) {
        response = await service.placeBetByColor(this.color, roulette.color, this.bet, this.amount);
      } else if (this.color && this.number && !this.evenOrOdd) {
        response = await service.placeBetByNumber(this.number, roulette.number, this.color, roulette.color, this.bet, this.amount);
      } else {
        const evenOrOddBool = this.evenOrOdd === 'Odd';
        response = await service.placeBetByEvenOrOdd(evenOrOddBool, roulette.number, this.color, roulette.color, this.bet, this.amount);
      }

      this.result = response.amount;
      this.isWin = response.isWin;
    },
    async saveBet() {
      const service = new RouletteService();
      const success = await service.saveBet(this.playerName, this.result);
      if (success) {
        alert('Bet saved successfully');
        router.push('/home');
      } else {
        alert('Error saving bet');
      }
    },
  },
};
</script>

<style scoped>
.card {
  border-radius: 1rem;
  background-color: #f8f9fa; /* Fondo más moderno */
}
</style>
