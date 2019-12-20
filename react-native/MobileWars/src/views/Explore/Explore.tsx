import React, { useState, useEffect } from 'react';
import { toJson } from 'unsplash-js';

import unsplash from '../../helpers/unsplash/unsplash';
import { getUnsplashDataFormated, IExploreProps } from './types';
import List from '../../components/List';
import Unsplash from '../../models/Unsplash';

const Explore: React.FC<IExploreProps> = ({ navigation }) => {
  const [images, setImages] = useState<Array<Unsplash>>([]);

  useEffect(() => {
    unsplash.search.photos('star wars')
    .then(toJson)
    .then(json => setImages(getUnsplashDataFormated(json.results)));
  }, []);

  return (
    <List images={images} onPress={(image: Unsplash) => navigation.navigate('Detail', { image })} />
  );
};

export default Explore;
