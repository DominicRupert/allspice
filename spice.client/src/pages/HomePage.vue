<template>
<div class="container">

  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div v-for="recipie in recipies" :key="recipie.id" :recipie="recipie">{{recipie.name}}{{recipie.ingredients}}</div>
    </div>
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
            await recipiesService.getAll()
            await recipiesService.getIngredients()
          } catch (error) {
            logger.error(error)
          }


          
        });
        return{
          recipies: computed(() => AppState.recipies)
        }
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
