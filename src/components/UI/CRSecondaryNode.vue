<script setup>
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

  <div style="background-color: crimson">

    <button @click="setModal(true)"> kek</button>

    <div>{{ props.node.title }} - {{ props.node.status }}</div>
  </div>
</template>
