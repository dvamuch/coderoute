<script setup>
import {computed, ref} from "vue";

const props = defineProps({
  placeholder: {
    type: String,
    default: "Пароль",
  },
  isValid: {
    type: Boolean,
    default: false,
    required: true,
  },
});
const emits = defineEmits([
  "update:password",
]);

const password = ref("");

const isShowingPassword = ref(false);

const visibilityIconStyle = computed(() => {
  return isShowingPassword.value ? "--crMsk: url('/icons/visibility_on.svg');" : "--crMsk: url('/icons/visibility_off.svg');";
});

const inputTypeForPassword = computed(() => {
  return isShowingPassword.value ? "text" : "password";
});
const reverseShowingPassword = () => {
  isShowingPassword.value = !isShowingPassword.value;
};
</script>

<template>
  <label class="crFormWrap">
    <input :type="inputTypeForPassword" :placeholder="props.placeholder" v-model="password"
           @input="emits('update:password', $event.target.value)"
           :class="{alert: !props.isValid}"
           class="crFormItem txt secondary hMedium radSmall"/>
    <span class="crFormPlaceholder">{{ props.placeholder }}</span>
    <span class="crFormIcon right">
          <span @click="reverseShowingPassword" class="crIcon sMedium" :style="visibilityIconStyle"></span>
        </span>
  </label>
</template>
