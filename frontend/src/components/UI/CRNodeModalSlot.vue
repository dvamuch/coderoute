<script setup>

import CRSelectStatus from "@/components/UI/CRSelect.vue";
import {useAuthorizationStore} from "@/stores/authorization";
import {useNodesStore} from "@/stores/nodes";
import {useNodeStatusStore} from "@/stores/nodeStatus";
import {computed, onMounted, ref} from "vue";

const props = defineProps({
  nodeId: {
    type: Number,
    required: true,
  },
});

const nodesStore = useNodesStore();
const authorizationStore = useAuthorizationStore();
const nodeStatusStore = useNodeStatusStore();

const nodeObject = ref({
  title: "",
  description: "",
  statusId: 1,
});

const isAuthorized = computed(() => authorizationStore.isAuthorized);

onMounted(async () => {
  // console.log(2, props.nodeId);
  await nodesStore.fetchNode(props.nodeId);
  const newNodeObject = nodesStore.nodeObjects[props.nodeId];
  nodeObject.value = newNodeObject;
  status.value = newNodeObject?.statusId || 1;
});


const changeNodeStatus = async (newStatusId) => {
  console.log(newStatusId);
  await nodesStore.updateStatus(props.nodeId, newStatusId);
};

const status = ref(1);

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
      <div class="flexibleY gapXSmallest" v-html="nodeObject.description"></div>
    </div>

  </div>

</template>
