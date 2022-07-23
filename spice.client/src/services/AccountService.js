import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
  async getMyRecipies() {
      const res = await api.get('account/recipies')
      logger.log('getMyRecipies', res.data)
      AppState.recipies = res.data
 
  }
  async getMyFavorites(favoriteId){
      const res = await api.get('account/favorites')
      logger.log('getMyFavorites', res.data)
      AppState.favorites = res.data

  }
}

export const accountService = new AccountService()
