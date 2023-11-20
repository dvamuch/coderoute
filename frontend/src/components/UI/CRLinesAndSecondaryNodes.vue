<script setup>

import CRSecondaryNode from "@/components/UI/CRSecondaryNode.vue";
import {useNodeStatusStore} from "@/stores/nodeStatus";
import {computed} from "vue";

const {getLineClassesByStatusId} = useNodeStatusStore();

const props = defineProps({
  indexInArray: {
    type: Number,
    required: true,
  },
  secondaryNodes: {
    type: Array,
    required: true,
  },
});

const isShowLeft = computed(() => props.indexInArray % 2 === 1);
const isShowRight = computed(() => props.indexInArray % 2 === 0);
</script>

<template>
  <div v-if="isShowLeft" class="sideIn">
    <div class="buttons">
      <CRSecondaryNode v-for="secondaryNode in secondaryNodes" v-bind:key="secondaryNode.id"
                       :title="secondaryNode.title" :id="secondaryNode.id"
                       :status-id="secondaryNode.statusId"></CRSecondaryNode>
    </div>

    <div class="lines">
      <div v-for="secondaryNode in secondaryNodes" v-bind:key="secondaryNode.id" class="curve">
        <svg viewBox="0 0 400 400" preserveAspectRatio="none">
          <path class="path" :class="getLineClassesByStatusId(secondaryNode.statusId)" d="M 0 400 C 0 300 200 0 400 0"/>
          <path class="path" :class="getLineClassesByStatusId(secondaryNode.statusId)" d="M 0 200 C 100 -200 300 -200 400 200"/>
          <path class="path" :class="getLineClassesByStatusId(secondaryNode.statusId)" d="M 0 0 C 100 0 300 100 400 400"/>
        </svg>
      </div>
    </div>
  </div>

  <div v-if="isShowRight" class="sideIn">
    <div class="lines">
      <div v-for="secondaryNode in secondaryNodes" v-bind:key="secondaryNode.id" class="curve">
        <svg viewBox="0 0 400 400" preserveAspectRatio="none">
          <path class="path" :class="getLineClassesByStatusId(secondaryNode.statusId)" d="M 0 400 C 0 300 200 0 400 0"/>
          <path class="path" :class="getLineClassesByStatusId(secondaryNode.statusId)" d="M 0 200 C 100 -200 300 -200 400 200"/>
          <path class="path" :class="getLineClassesByStatusId(secondaryNode.statusId)" d="M 0 0 C 100 0 300 100 400 400"/>
        </svg>
      </div>
    </div>

    <div class="buttons">
      <CRSecondaryNode v-for="secondaryNode in secondaryNodes" v-bind:key="secondaryNode.id"
                       :title="secondaryNode.title" :id="secondaryNode.id"
                       :status-id="secondaryNode.statusId"></CRSecondaryNode>
    </div>
  </div>
</template>
