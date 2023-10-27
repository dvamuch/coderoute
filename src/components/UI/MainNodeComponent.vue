<script setup>
import SecondaryNodeComponent from "@/components/UI/SecondaryNodeComponent.vue";

const props = defineProps({
  title: {
    type: String,
    required: true,
  },
  status: {
    type: String,
    required: true,
  },
  secondaryNodes: {
    type: Array,
    required: true,
  },
});
</script>

<template>
  <div>{{ props.title }}</div>
  <SecondaryNodeComponent v-for="node in secondaryNodes" v-bind:key="node" :title="node.title"
                          :status="node.status"></SecondaryNodeComponent>
</template>

<style scoped>

</style>
