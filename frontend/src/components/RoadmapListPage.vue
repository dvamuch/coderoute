<script setup>

import CRRoadmapListGroup from "@/components/UI/CRRoadmapListGroup.vue";
import userFetcher from "@/use/fetcher";
import {onMounted, ref} from "vue";

const fetcher = userFetcher();

const roadmapGroupList = ref([]);

onMounted(async () => {
  roadmapGroupList.value = await fetcher.fetchJson(`http://${process.env.VUE_APP_BACKEND_HOST}/api/v1/Routes`);
});

</script>

<template>
  <main class="crMain flexibleY gapMedium">
    <header class="crHeader">
      <div class="flexibleY gapSmaller">
        <h2 class="fn-caption"><b>Дорожные карты</b></h2>
      </div>
    </header>

    <CRRoadmapListGroup v-for="roadmapGroup in roadmapGroupList" :roadmap-list="roadmapGroup.routes" :profession-name="roadmapGroup.direction"></CRRoadmapListGroup>
<!--    <CRRoadmapListGroup :roadmap-list="oadmapList" profession-name="Аналитика"></CRRoadmapListGroup>-->
<!--    <CRRoadmapListGroup :roadmap-list="oadmapList" profession-name="Дизайн"></CRRoadmapListGroup>-->
  </main>
</template>
