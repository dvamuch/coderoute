<script setup>

defineProps({
  title: {
    type: String,
    required: true,
  },
  status: {
    type: String,
    required: true,
  },
  id: {
    type: Number,
    required: true,
  },
});

</script>

<template>

  <div class="crFormItem button noShrink completed radMedium filled hMedium"> {{ title }}</div>
</template>
