<script setup>

import CRLinesAndSecondaryNodes from "@/components/UI/CRLinesAndSecondaryNodes.vue";
import {useNodeModalStore} from "@/stores/nodeModal";
import {useNodeStatusStore} from "@/stores/nodeStatus";
import {computed} from "vue";

const {getNodeClassesByStatusId, getVerticalLineClassesByStatusId} = useNodeStatusStore();

const {openNodeModal} = useNodeModalStore();

const props = defineProps({
  title: {
    type: String,
    required: true,
  },
  statusId: {
    type: Number,
    required: true,
  },
  id: {
    type: Number,
    required: true,
  },
  secondaryNodes: {
    type: Array,
    required: true,
  },
  indexInArray: {
    type: Number,
    required: true,
  },
});


const isShowLeft = computed(() => props.indexInArray % 2 === 1);
const isShowRight = computed(() => props.indexInArray % 2 === 0);
</script>

<template>
  <div class="vLine" :class="getVerticalLineClassesByStatusId(statusId)"></div>
  <div class="treeBlock">

    <div class="section side left">
      <CRLinesAndSecondaryNodes v-if="isShowLeft" :secondary-nodes="secondaryNodes"
                                :index-in-array="indexInArray">
      </CRLinesAndSecondaryNodes>
    </div>

    <div class="section">

      <div class="crFormItem button noShrink radSmall hMedium" :class="getNodeClassesByStatusId(statusId)"
           @click="openNodeModal"> {{ props.title }}
      </div>

    </div>

    <div class="section side right">
      <CRLinesAndSecondaryNodes v-if="isShowRight" :secondary-nodes="secondaryNodes"
                                :index-in-array="indexInArray">
      </CRLinesAndSecondaryNodes>
    </div>

  </div>
</template>
