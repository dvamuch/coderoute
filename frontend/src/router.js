import MainPage from "@/components/MainPage.vue";
import RoadmapListPage from "@/components/RoadmapListPage.vue";
import RoadmapPage from "@/components/RoadmapPage.vue";
import {useAuthorizationStore} from "@/stores/authorization";
import {createRouter, createWebHashHistory} from "vue-router";


const routes = [
  {path: "/", component: MainPage},
  {path: "/roadmaps", component: RoadmapListPage},
  {path: "/roadmaps/:id", component: RoadmapPage},
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

router.beforeEach(() => {
  const authorizationStore = useAuthorizationStore();

  authorizationStore.checkAuth();
});

export default router;
