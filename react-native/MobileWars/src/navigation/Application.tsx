
import React from 'react';
import { createStackNavigator } from 'react-navigation-stack';
import { createBottomTabNavigator } from 'react-navigation-tabs';

import Detail from '../views/Explore/Detail';
import Explore from '../views/Explore';
import Favourites from '../views/Favourites';
import Icon from '../components/Icon';

const photo = require('../assets/photo.png');
const favourite = require('../assets/favourite.png')

const ExploreTab = createStackNavigator({
  Explore: {
    screen: Explore,
  },
  Detail: {
    screen: Detail,
    navigationOptions: {
      title: 'Detail',
    },
  },
}, {
  mode: 'modal',
});

const FavouritesTab = createStackNavigator({
  Favourites: {
    screen: Favourites,
    navigationOptions: {
      title: 'Favorites',
    }
  },
});

const Application = createBottomTabNavigator({
  Explore: {
    screen: ExploreTab,
    navigationOptions: {
      title: 'Explore',
      tabBarIcon: <Icon source={photo} />,
    },
  },
  Favourites: {
    screen: FavouritesTab,
    navigationOptions: {
      tabBarIcon: <Icon source={favourite} />
    },
  },
});



export default Application;