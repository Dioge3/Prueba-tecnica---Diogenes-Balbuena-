import { createRouter, createWebHistory } from "vue-router";
import HomePage from "../views/HomeView.vue";
import GamePage from "../views/GameView.vue";

const routes = [
  {
    path: "/",
    name: "HomePage",
    component: HomePage,
  },
  {
    path: "/home",
    name: "HomePage",
    component: HomePage,
  },
  {
    path: "/play/:playerName",
    name: "GamePage",
    component: GamePage,
    props: true, // Para pasar playerName como prop
  },
  {
    path: "/:catchAll(.*)*", // Ruta catch-all
    redirect: "/home",
  },
];

const router = createRouter({
  history: createWebHistory(), // En JS no usamos process.env.BASE_URL a menos que lo definas
  routes,
});

export default router;
