<template>
<div class="container-fluid d-flex flex-row bg-dark">
<div class="row">

  <div class=" d-flex flex-column ">
    <Recipie v-for="recipie in recipies" :key="recipie.id" :recipie="recipie"></Recipie>
    </div>
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
