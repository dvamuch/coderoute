<script setup>
import {ref} from "vue";

const props = defineProps({
  placeholder: {
    type: String,
    default: "Текстовое поле",
  },
});

defineEmits([
  "update:text",
]);

const text = ref("");

</script>

<template>
  <label class="crFormWrap">
    <input type="text" :placeholder="props.placeholder" class="crFormItem txt secondary hMedium radSmall" v-model="text"
           @change="$emit('update:text', $event.target.value)"/>
    <span class="crFormPlaceholder">{{ props.placeholder }}</span>
  </label>
</template>
