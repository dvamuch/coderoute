<script setup>

import CRRoadmapListGroup from "@/components/UI/CRRoadmapListGroup.vue";
import {onMounted, ref} from "vue";

const developerRoadmapList = ref([]);

onMounted(async () => {
  developerRoadmapList.value = await (await fetch(`http://${process.env.VUE_APP_BACKEND_HOST}/api/v1/Routes`)).json();
});

</script>

<template>
  <main class="crMain flexibleY gapMedium">
    <header class="crHeader">
      <div class="flexibleY gapSmaller">
        <h2 class="fn-caption"><b>Дорожные карты</b></h2>
      </div>
    </header>

    <CRRoadmapListGroup :roadmap-list="developerRoadmapList" profession-name=""></CRRoadmapListGroup>
  </main>
</template>
