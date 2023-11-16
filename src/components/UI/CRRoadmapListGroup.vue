<script setup>

import CRRoadmapListCard from "@/components/UI/CRRoadmapListCard.vue";
import CRRoadmapRecommendCard from "@/components/UI/CRRoadmapRecommendCard.vue";

const props = defineProps({
  professionName: {
    type: String,
    required: true,
  },
  roadmapList: {
    type: Array,
    required: true,
  },
});

</script>

<template>
  <section class="flexibleY gapSmall wmxAltContent">
    <h3 class="fn-subcap"><b> {{ props.professionName}}</b></h3>
    <ul class="crCards x2 gapSmaller">
      <CRRoadmapListCard v-for="roadmapElement in props.roadmapList" v-bind:key="roadmapElement.roadmapId"
                         :title="roadmapElement.title"
                         :roadmap-id="roadmapElement.roadmapId" :percents-of-progress="roadmapElement.progress"
                         :is-started="roadmapElement.isStarted"
                         :description="roadmapElement.description"></CRRoadmapListCard>
      <CRRoadmapRecommendCard></CRRoadmapRecommendCard>
    </ul>
  </section>
</template>
