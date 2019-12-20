import _ from 'underscore';
import AsyncStorage from '@react-native-community/async-storage';

import Favourite from '../models/Favourite';

const setData = ({ unsplash, desc }: Favourite) => {
  getData()
  .then(data => {
    data.push({ unsplash, desc });
    AsyncStorage.setItem('favourites', JSON.stringify(data))
  })
};

const removeData = ({ unsplash, desc }: Favourite) => {
  getData()
  .then(data => {
    const newData = data.filter(item => {
      if (!_.isEqual(item.unsplash, unsplash)) {
        return item;
      }
    })
    AsyncStorage.setItem('favourites', JSON.stringify(newData));
  });
}

const getData = async (): Promise<Array<Favourite>> => {
  try {
    const json = await AsyncStorage.getItem('favourites')
    if (json !== null) {
      const value = JSON.parse(json);
      return value;
    }
  } catch(e) {
    console.log(e);
  }
  return [];
};

export { getData, setData, removeData };