<script setup>

import CRSecondaryNode from "@/components/UI/CRSecondaryNode.vue";
import {useAppStore} from "@/stores/app";

const {setModal} = useAppStore();

const props = defineProps({
  node: {
    type: Object,
    required: true,
  },
});



</script>

<template>
  <div style="background-color: #42b983">

    <button @click="setModal(true)"> kek</button>

    <div>{{ props.node.title }}</div>
  </div>


  <CRSecondaryNode v-for="secondaryNode in props.node.secondaryNodes" v-bind:key="secondaryNode.id"
                   :node="secondaryNode"></CRSecondaryNode>
</template>

