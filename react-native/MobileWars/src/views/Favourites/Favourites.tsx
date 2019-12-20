import React, { useState, useEffect } from 'react';

import List from '../../components/List';
import Favourite from '../../models/Favourite';
import Unsplash from '../../models/Unsplash';
import { getData } from '../../helpers/storage';
import { IFavouritesProps } from './types';


const Favourites: React.FC<IFavouritesProps> = ({ navigation }) => {
  const [images, setImages] = useState<Array<Favourite>>([]);
  
  useEffect(() => {
    getData()
    .then(data => setImages(data));
  }, []);

  return (
    <List images={images.map(image => image.unsplash)} onPress={(image: Unsplash) => navigation.navigate('Detail', { image })} />
  );
};

export default Favourites;
