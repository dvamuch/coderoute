<script setup>

import {computed, ref} from "vue";

const props = defineProps({
  modelValue: {
    type: Number,
    required: true,
  },
  items: {
    type: Array,
    required: true,
  },
});

const emits = defineEmits([
  "update:model-value",
]);

const currentItem = computed(() => props.items.find((element) => element.id === props.modelValue));
const currentTitle = computed(() => currentItem.value.name);
const currentClass = computed(() => currentItem.value.class);
const filteredItems = computed(() => props.items.filter((i) => i.id !== props.modelValue));

const expanded = ref(false);

const changeItem = (newId) => {
  emits("update:model-value", newId);
};
</script>

<template>
  <div class="flexible">

    <div class="crSelect flexible" :class="{active: expanded}">
      <div class="crFormItem crSelectInput button noShrink secondary radSmall hSmall gapMini" style="min-width: 180px;">
        <div class="sSmallest crFormItem radRound" :class="currentClass"></div>
        <div class="grow"> {{ currentTitle }}</div>
      </div>
      <div class="crFormItem crSelectButton button noShrink primary filled radSmall hSmall gapMini"
           @click="expanded = !expanded">
        <div>Обновить статус</div>
        <div class="crSelectArrow"></div>
        <div class="crSelectContent bg-background">
          <ul class="borderedList">
            <li v-for="item in filteredItems"
                class="item flexible gapMini link" @click="changeItem(item.id)">
              <div class="sSmallest crFormItem radRound" :class="item.class"></div>
              <div>{{ item.name }}</div>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>
