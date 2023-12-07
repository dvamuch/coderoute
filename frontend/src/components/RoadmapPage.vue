<script setup>

import CRMainAndSecondaryNodes from "@/components/UI/CRMainAndSecondaryNodes.vue";
import {useHelpModalStore} from "@/stores/helpModal";
import {useNodesStore} from "@/stores/nodes";
import {computed, onMounted} from "vue";
import {useRoute} from "vue-router";

const route = useRoute();

const helpModal = useHelpModalStore();
const nodesStore = useNodesStore();


const nodes = computed(() => nodesStore.nodeList);
const roadmap = computed(() => nodesStore.roadmapInfo);
const progress = computed(() => nodesStore.roadmapProgress);

onMounted(async () => {
  await nodesStore.fetchRoadmap(route.params.id);
});


</script>

<template>
  <main class="crMain flexibleY gapMedium">
    <header class="crHeader">
      <div class="flexibleY gapSmaller">
        <h2 class="fn-caption"><b>{{ roadmap.title }}</b></h2>
        <p>{{ roadmap.description }}</p>
      </div>
    </header>

    <div class="crProgressHead flexible bg-secondary radRound">
      <div class="flexible grow gapXSmallest">
        <div class="crFormItem button noShrink completed radSmall filled hSmall">{{ progress.percent }}% пройдено</div>
        <ul class="statList flexible">
          <li class="item">{{ progress.finished }} изучено</li>
          <li class="item">{{ progress.inProgress }} в процессе</li>
          <li class="item">{{ progress.skipped }} пропущено</li>
          <li class="item">{{ progress.total }} всего</li>
        </ul>
      </div>
      <div class="flexible noShrink gapXSmallest" @click="helpModal.openHelpModal">
        <div class="crIcon bg-accent" style="--crMsk: url('/icons/question.svg');"></div>
        <div>Отслеживание прогресса</div>
      </div>
    </div>


    <div class="crTree">

      <CRMainAndSecondaryNodes
          v-for="(node, index) in nodes"
          v-bind:key="node.id"
          :id="node.id"
          :title="node.title"
          :index-in-array="index"
          :secondary-nodes="node.secondaryNodes"
          :status-id="node.statusId">
      </CRMainAndSecondaryNodes>

    </div>

  </main>
</template>

