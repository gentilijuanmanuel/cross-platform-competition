import React, { useState, useEffect, useContext } from 'react';
import {
  View,
  Text,
  StyleSheet,
  TouchableOpacity,
  Image,
  TextInput
} from 'react-native';
import _ from 'underscore';

import { getData, removeData, setData } from '../../../helpers/storage';
import { IDetailProps } from './types';
import ThemeContext, { ThemeConstants } from '../../../context/theme';

const favouriteFilledIcon = require('../../../assets/favourite.png');
const favouriteBorderIcon = require('../../../assets/bookmark_border-24px.png');

const Detail: React.FC<IDetailProps> = ({ navigation }) => {
  const unsplash = navigation.getParam('image');
  const [desc, setDesc] = useState('');
  const [isFavourite, setFavourite] = useState(false);
  const theme = useContext(ThemeContext);

  useEffect(() => {
    getData()
    .then(data => {
      data.map(item => {
        if (_.isEqual(item.unsplash, unsplash)) {
          setDesc(item.desc);
          setFavourite(true);
        }
      })
    })
  }, []);

  const getBackgroundColor = () => {
    const backgroundColor = ThemeConstants[theme.themeValue].backgroundColor;
    return { backgroundColor };
  };

  const getFavouriteStyle = () => {
    const tintColor = ThemeConstants[theme.themeValue].fontColor;
    return { tintColor };
  };

  const getInputStyle = () => {
    const borderBottomColor = ThemeConstants[theme.themeValue].fontColor;
    const color = ThemeConstants[theme.themeValue].fontColor;
    return { borderBottomColor, color };
  };

  const getDescriptionTextStyle = () => {
    const color = ThemeConstants[theme.themeValue].fontColor;
    return { color };
  };

  const addFavourite = () => {
    setData({ unsplash, desc });
    setFavourite(true);
  };

  const removeFavourite = () => {
    removeData({ unsplash, desc });
    setFavourite(false);
  };

  const onFavourite = () => {
    if (isFavourite) {
      removeFavourite();
    } else {
      addFavourite();
    }
  };

  return (
    <View style={[styles.container, getBackgroundColor()]}>
      <Image
        source={unsplash}
        style={styles.imageStyle}
      />
      <View style={styles.descriptionContainer}>
        <Text style={[styles.descriptionStyle, getDescriptionTextStyle()]}>{unsplash.description}</Text>
        <TouchableOpacity onPress={() => onFavourite()}>
          {
            isFavourite
            ? <Image source={favouriteFilledIcon} style={[styles.favouriteIconStyle, getFavouriteStyle()]} />
            : <Image source={favouriteBorderIcon} style={[styles.favouriteIconStyle, getFavouriteStyle()]} />
          }
        </TouchableOpacity>
      </View>
      <View style={{ alignSelf: 'stretch', flex: 1 }}>
        <TextInput
          editable={!isFavourite}
          onChangeText={value => setDesc(value)}
          placeholder="Description"
          placeholderTextColor={ThemeConstants[theme.themeValue].fontColor}
          style={[styles.inputStyle, getInputStyle()]}
          value={desc}
        />
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    alignItems: 'center',
    flex: 1,
    paddingLeft: 16,
    paddingTop: 24,
    paddingRight: 16,
  },
  descriptionContainer: {
    alignItems: 'center',
    flex: 1,
    flexDirection: 'row',
    justifyContent: 'space-between',
  },
  descriptionStyle: {
    flex: 1,
  },
  favouriteIconStyle: {
    height: 24,
    marginLeft: 24,
    width: 24,
  },
  inputStyle: {
    borderBottomColor: 'white',
    borderBottomWidth: StyleSheet.hairlineWidth,
  },
  imageStyle: {
    borderRadius: 24,
    height: 450,
    marginBottom: 24,
    width: '100%',
  }
});

export default Detail;
