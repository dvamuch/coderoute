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
  {{ props.isValid }}
  <label class="crFormWrap">
    <input type="text" :placeholder="props.placeholder" class="crFormItem txt hMedium radSmall primary"
           :class="{alert: !props.isValid, primary: props.isValid}"
           v-model="text"
           @input="$emit('update:text', $event.target.value)"/>
    <span class="crFormPlaceholder">{{ props.placeholder }}</span>
  </label>
</template>
