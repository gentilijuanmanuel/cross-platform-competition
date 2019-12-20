import { NavigationStackProp } from 'react-navigation-stack';

import Unsplash from '../../models/Unsplash';

export const getUnsplashDataFormated = (unsplashData: any): Array<Unsplash> => {
  return unsplashData.map((item: any) => {
    return {
      description: item.description,
      id: item.id,
      url: item.urls.regular,
    };
  });
};

export interface IExploreProps {
  navigation: NavigationStackProp,
}
