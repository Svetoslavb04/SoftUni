import { Header } from './components/Header.js';
import { Slider } from './components/Slider.js';
import { Welcome } from './components/Welcome.js';
import { Service } from './components/Service.js';
import { Security } from './components/Security.js';
import { Story } from './components/Story.js';
import { Contact } from './components/Contact.js';
import { Info } from './components/Info.js';
import { Footer } from './components/Footer.js';

function App() {
  return (
    <div>
      <Header />
      <Slider />
      <Welcome />
      <Service />
      <Security />
      <Story />
      <Contact />
      <Info />
      <Footer />
    </div>
  );
}

export default App;
