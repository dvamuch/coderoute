<script setup>

import {useNodeModalStore} from "@/stores/nodeModal";
import {useNodeStatusStore} from "@/stores/nodeStatus";

const {getNodeClassesByStatusId} = useNodeStatusStore();
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
});

</script>

<template>
  <div class="crFormItem button noShrink radMedium hMedium" :class="getNodeClassesByStatusId(props.statusId)" @click="openNodeModal"> {{ title }}</div>
</template>
