<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    </div>
    <div v-for="r in recipies" :key="r.id" class="col-md-4">
  <Recipie :recipie="r" />

  </div>
</template>

<script>
import { logger } from '../utils/Logger.js'
import {computed, onMounted, ref} from '@vue/runtime-core'
import { AppState } from '../AppState.js'
import { recipiesService } from '../services/RecipiesService.js'




export default {
    name: "Home",
    setup() {
        onMounted(async () => {
          try {
            await recipiesService.getRecipies()
          } catch (error) {
            logger.error(error)
          }

          
        });
    },
}
</script>

<style scoped lang="scss">
.home{
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card{
    width: 50vw;
    > img{
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
