import React, { useContext } from 'react';
import { View, StyleSheet, ScrollView, Text } from 'react-native';
import { withNavigation } from 'react-navigation';

import ListItem from '../ListItem';
import { IListProps } from './types';
import ThemeContext, { ThemeConstants } from '../../context/theme';

const List: React.FC<IListProps> = ({ images, onPress }) => {
  const theme = useContext(ThemeContext);

  const getBackgroundColor = () => {
    const backgroundColor = ThemeConstants[theme.themeValue].backgroundColor;
    return { backgroundColor };
  };

  return (
    <ScrollView
      contentContainerStyle={[styles.container, getBackgroundColor()]}
      contentInsetAdjustmentBehavior="automatic"
    >
      <View style={[styles.itemContainer, { paddingRight: 8 }]}>
        {images.slice(0, 4).map((image, index) => {
          return (
            <ListItem
              key={image.id}
              image={image}
              index={index}
              onPress={() => onPress(image)}
            />
          );
        })}
      </View>
      <View style={[styles.itemContainer, { paddingLeft: 8 }]}>
        {images.slice(5, 9).map((image, index) => {
          return (
            <ListItem
              key={image.id}
              image={image}
              index={index + 1}
              onPress={() => onPress(image)}
            />
          );
        })}
      </View>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    flexDirection: 'row',
    paddingTop: 24,
    paddingLeft: 16,
    paddingRight: 16,
  },
  itemContainer: {
    flex: 1,
  },
});

export default withNavigation(List);
