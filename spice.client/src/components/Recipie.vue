<template>
  <div class="recipie-card container-fluid selectable" @click="selectRecipie">
    <div class="recipe-card-content row">
      <div class="col-md-4">
        <h3 class="">{{ recipie.name }}</h3>
        <h3>{{ recipie.ingredients }}</h3>
        <p>{{ recipie.id }}</p>
        <p>{{ recipie.steps }}</p>
        <img src="https://thiscatdoesnotexist.com" class="" alt="" />
      </div>
    </div>
  </div>
</template>


<script>
import { computed, onMounted, ref } from '@vue/runtime-core'
import { AppState } from '../AppState.js'
import { recipiesService } from '../services/RecipiesService.js'
import { logger } from '../utils/Logger.js'

export default {
  props: {
    recipie: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {
      recipies: computed(() => AppState.recipies)


    }
  }
}
</script>


<style lang="scss" scoped>
</style>