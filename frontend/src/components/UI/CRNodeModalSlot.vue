<script setup>

const props = defineProps({
  nodeId: {
    type: Number,
    required: true,
  },
});

import CRSelectStatus from "@/components/UI/CRSelect.vue";
import {useAuthorizationStore} from "@/stores/authorization";
import {useNodesStore} from "@/stores/nodes";
import {useNodeStatusStore} from "@/stores/nodeStatus";
import {computed, onMounted, ref} from "vue";

const nodesStore = useNodesStore();
const authorizationStore = useAuthorizationStore();
const nodeStatusStore = useNodeStatusStore();

const nodeObject = computed(() => {
  console.log(11, nodesStore.nodeObjects[props.nodeId]);
  return nodesStore.nodeObjects[props.nodeId] || {};
});

const isAuthorized = computed(() => authorizationStore.isAuthorized);

onMounted(async () => {
  console.log(2, props.nodeId);
  await nodesStore.fetchNode(props.nodeId);
});


const changeNodeStatus = async (newStatusId) => {
  console.log(newStatusId);
};

const status = ref(1);
// const status = computed(() => nodeObject.value.statusId);

</script>

<template>

  <div class="flexibleY gapMedium">
    <div class="flexibleY gapXSmallest">

      <!--      {{ status}}-->
      <!--      {{ nodeStatusStore.statuses}}-->
      <div class="flexible">
        <template v-if="isAuthorized">
          <CRSelectStatus :items="nodeStatusStore.statuses" v-model="status"
                          @update:model-value="changeNodeStatus"></CRSelectStatus>
        </template>
      </div>

      <h6 class="fn-subcap"><b>{{ nodeObject.title }}</b></h6>
      <p class="lhMain">{{ nodeObject.description }}</p>
      <!--      <p class="lhMain">Чтобы узнать больше, изучите следующие материалы:</p>-->
      <!--      <ul class="linkedList fn-accent">-->
      <!--        <li class="item">-->
      <!--          <a title="" href="#" class="link">Как работает интернет?</a>-->
      <!--        </li>-->
      <!--        <li class="item">-->
      <!--          <a title="" href="#" class="link">Интернет в деталях</a>-->
      <!--        </li>-->
      <!--        <li class="item">-->
      <!--          <a title="" href="#" class="link">Введение в интернет</a>-->
      <!--        </li>-->
      <!--        <li class="item">-->
      <!--          <a title="" href="#" class="link">Как работает Web?</a>-->
      <!--        </li>-->
      <!--      </ul>-->
    </div>

  </div>

</template>
