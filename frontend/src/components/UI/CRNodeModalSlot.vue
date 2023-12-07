<script setup>

const props = defineProps({
  nodeId: {
    type: Number,
    required: true,
  },
});

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
  await nodesStore.fetchNode(props.nodeId);
  console.log(2, nodesStore.nodeObjects);
});

const isStatusChangeUlActive = ref(false);

const changeNodeStatus = async () => {

};

</script>

<template>

  <div class="flexibleY gapMedium">
    <div class="flexibleY gapXSmallest">


      <div class="flexible">

        <div v-if="isAuthorized" class="crSelect flexible" :class="{active: isStatusChangeUlActive}">
          <div class="crFormItem crSelectInput button noShrink secondary radSmall hSmall gapMini">
            <div class="sSmallest crFormItem radRound"
                 :class="nodeStatusStore.getNodeClassesByStatusId(nodeObject.statusId)"></div>
            <div class="grow"> {{ nodeStatusStore.getNameByStatusId(nodeObject.statusId) }}</div>
          </div>
          <div class="crFormItem crSelectButton button noShrink primary filled radSmall hSmall gapMini"
               @click="isStatusChangeUlActive = !isStatusChangeUlActive">
            <div>Обновить статус</div>
            <div class="crSelectArrow">df</div>
          </div>

          <div class="crSelectContent bg-background">
            <ul class="borderedList">
              <li class="item flexible gapMini link">
                <div class="sSmallest crFormItem radRound secondary2 filled"></div>
                <div>Пропустил</div>
              </li>
              <li class="item flexible gapMini link">
                <div class="sSmallest crFormItem radRound primary"></div>
                <div>Не изучаю</div>
              </li>
              <li class="item flexible gapMini link">
                <div class="sSmallest crFormItem radRound primary filled"></div>
                <div>В процессе</div>
              </li>
              <li class="item flexible gapMini link">
                <div class="sSmallest crFormItem radRound completed filled"></div>
                <div>Изучил</div>
              </li>
            </ul>
          </div>
        </div>
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
