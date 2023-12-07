<script setup>

const props = defineProps({
  title: {
    type: String,
    required: true,
  },
  description: {
    type: String,
    required: true,
  },
  isStarted: {
    type: Boolean,
    default: false,
  },
  percentsOfProgress: {
    type: Number,
    default: 0,
  },
  roadmapId: {
    type: Number,
    required: true,
  },
});

</script>

<template>
  <ul class="crCards x2 gapSmaller">
    <li class="crCard flexibleY stretch gapXSmallest">
      <h4 class="fn-adv"><b>{{ props.title }}</b></h4>
      <p class="lhMain">{{ props.description }}</p>
      <div class="flexible flex-bottom">
        <div class="fn-completed grow">
          <div v-if="isStarted">{{ props.percentsOfProgress }}% пройдено</div>
        </div>
<!--        <p>{{ "/roadmaps/" + props.roadmapId }}</p>-->
        <router-link title="" :to="'/roadmaps/' + props.roadmapId"
                     class="crFormItem button noShrink primary radRound filled hMedium">
          {{isStarted? "Продолжить" : "Ознакомиться"}}
        </router-link>
      </div>
    </li>
  </ul>
</template>
