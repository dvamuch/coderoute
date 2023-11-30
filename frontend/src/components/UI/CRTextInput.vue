<script setup>
const props = defineProps({
  placeholder: {
    type: String,
    default: "Текстовое поле",
  },
});
</script>

<template>
  <label class="crFormWrap">
    <input type="text" :placeholder="props.placeholder" class="crFormItem txt secondary hMedium radSmall"/>
    <span class="crFormPlaceholder">{{ props.placeholder }}</span>
  </label>
</template>
