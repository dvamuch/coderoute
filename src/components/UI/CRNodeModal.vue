<script setup>
const props = defineProps({
  node: {
    type: Object,
    required: true,
  },
});
import {useAppStore} from "@/stores/app";
const {setModal} = useAppStore();

// const test = () => {
//   console.log('test');
// }

</script>

<template>
  <div class="modal-mask">
    <div class="modal-wrapper">
      <div class="modal-container" v-click-out="() => setModal(false)">
        <div>{{ props.node.status }}</div>
        <select>
          <option value="">Обновить статус</option>
          <option value="skipped">Пропустил</option>
          <option value="not_started">Не изучаю</option>
          <option value="in_process">В процессе</option>
        </select>

        <h3>{{ props.node.title }}</h3>

        {{ props.node.description }}

        <button class="modal-default-button" @click="setModal(false)">
          Close
        </button>

      </div>
    </div>
  </div>
</template>

