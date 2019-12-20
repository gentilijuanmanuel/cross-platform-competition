import React from 'react';
import { TouchableHighlight, Image, StyleSheet } from 'react-native';

import { IListItemProps } from './types';

const getImageStyle = (index: number): { height: number } => {
  const isEven: boolean = index % 2 === 0;
  const imageHeight: number = isEven ? 248 : 184;
  return {
    height: imageHeight,
  }
};

const ListItem: React.FC<IListItemProps> = ({ image, index, onPress }) => {
  return (
    <TouchableHighlight style={styles.container} onPress={() => onPress()}>
      <Image
        style={[styles.image, getImageStyle(index)]}
        source={{ uri: image.url }}
      />
    </TouchableHighlight>
  );
};

const styles = StyleSheet.create({
  container: {
    alignItems: 'center',
    marginBottom: 16,
  },
  image: {
    borderRadius: 24,
    width: 172,
  }
});

export default ListItem;
