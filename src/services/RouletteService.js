import axios from "axios";

export class RouletteService {
  constructor() {
    this.http = axios.create({
      baseURL: "https://localhost:44351/api/roulette",
      headers: {
        "Content-Type": "application/json",
      },
    });
  }

  async getUserAmount(name) {
    try {
      const response = await this.http.get(`/player/${name}`);
      if (response.data.success) {
        return response.data.data;
      }
      return null;
    } catch (error) {
      console.error(error);
      return null;
    }
  }

  async saveBet(name, amount) {
    try {
      const response = await this.http.post("/player/addOrUpdate", { name, amount });
      return response.data.success || false;
    } catch (error) {
      console.error(error);
      return false;
    }
  }

  async getNumberAndColor() {
    try {
      const response = await this.http.get("/openGame");
      if (response.data.success) {
        return response.data.data;
      }
      return null;
    } catch (error) {
      console.error(error);
      return null;
    }
  }

  async placeBetByColor(userColor, rouletteColor, bet, amount) {
    try {
      const response = await this.http.post("/betColor", {
        amount,
        bet,
        colorSelected: userColor,
        colorRoulette: rouletteColor,
      });
      if (response.data.success) {
        return response.data.data;
      }
      return null;
    } catch (error) {
      console.error(error);
      return null;
    }
  }

  async placeBetByNumber(userNumber, rouletteNumber, userColor, rouletteColor, bet, amount) {
    try {
      const response = await this.http.post("/betNumberAndColor", {
        amount,
        bet,
        colorSelected: userColor,
        colorRoulette: rouletteColor,
        numberSelected: userNumber,
        numberRoulette: rouletteNumber,
      });
      if (response.data.success) {
        return response.data.data;
      }
      return null;
    } catch (error) {
      console.error(error);
      return null;
    }
  }

  async placeBetByEvenOrOdd(isOdd, rouletteNumber, userColor, rouletteColor, bet, amount) {
    try {
      const response = await this.http.post("/betOddOrEven", {
        amount,
        bet,
        colorSelected: userColor,
        colorRoulette: rouletteColor,
        numberRoulette: rouletteNumber,
        isOdd,
      });
      if (response.data.success) {
        return response.data.data;
      }
      return null;
    } catch (error) {
      console.error(error);
      return null;
    }
  }
}
