import React, { useState } from 'react';
import {
  StatusBar,
  View,
  TouchableOpacity,
  Text,
} from 'react-native';
import { createAppContainer } from 'react-navigation';

import Application from './src/navigation/Application';
import ThemeContext, { ThemeType } from './src/context/theme';

const AppNav = createAppContainer(Application);


const App: React.FC<{}> = () => {
  const [theme, setTheme] = useState<ThemeType['themeValue']>('dark');

  const handleTheme = () => {
    const newTheme = theme === 'dark' ? 'light' : 'dark';
    setTheme(newTheme);
  }

  return (
    <ThemeContext.Provider
      value={{ themeValue: theme }}
    >
      <View style={{ backgroundColor: '#303030', flex: 1 }}>
        <StatusBar barStyle="dark-content" />
        <AppNav theme={theme === 'other' ? 'dark' : theme} />
        {/* <TouchableOpacity style={{ height: 98, justifyContent: 'center' }} onPress={handleTheme}>
          <Text
            style={{ textAlign: 'center', color: 'white' }}
          >
            Change Theme
          </Text>
        </TouchableOpacity> */}
      </View>
    </ThemeContext.Provider>
  );
};

export default App;