<script setup>
import {ref} from "vue";

const props = defineProps({
  placeholder: {
    type: String,
    default: "Текстовое поле",
  },
  isValid: {
    type: Boolean,
    default: false,
    required: true,
  },
});

defineEmits([
  "update:text",
]);

const text = ref("");

</script>

<template>
  <label class="crFormWrap">
    <input type="text" :placeholder="props.placeholder"
           :class="{alert: !props.isValid, secondary: props.isValid}" class="crFormItem txt hMedium radSmall "
           v-model="text"
           @input="$emit('update:text', $event.target.value)"/>
    <span class="crFormPlaceholder">{{ props.placeholder }}</span>
  </label>
</template>
