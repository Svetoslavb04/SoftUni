export const Info = () => (<section class="info_section layout_padding">
<div class="container">
  <div class="row">
    <div class=" col-md-4 info_detail">
      <div>
        <p>
          There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration
          in some form, by injected humour, or randomised words which don't look even slightly believable.
        </p>
      </div>
    </div>
    <div class=" col-md-4 address_container">
      <div>
        <h3>
          Address:
        </h3>
        <div class="address_link-container">
          <a href="">
            <img src="images/location.png" alt=""/>
            <span> Address: 73 Canal Street, New York, NY
            </span>
          </a>
          <a href="">
            <img src="images/phone.png" alt=""/>
            <span> Tel: +1 123 456 789
            </span>
          </a>
          <a href="">
            <img src="images/mail.png" alt=""/>
            <span>
              Email: demo@gmail.com
            </span>
          </a>
        </div>
      </div>
    </div>
    <div class=" col-md-4 news_container">
      <div>
        <div>
          <h3>
            newsletter

          </h3>
          <form action="">
            <input type="email" placeholder="ENTER YOUR EMAIL"/>
            <div>
              <button type="submit">
                Subscribe
              </button>
            </div>
          </form>
        </div>
        <div class="social_container">
          <div>
            <img src="images/fb.png" alt=""/>
          </div>
          <div>
            <img src="images/twitter.png" alt=""/>
          </div>
          <div>
            <img src="images/linkedin.png" alt=""/>
          </div>
          <div>
            <img src="images/youtube.png" alt=""/>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
</section>
);